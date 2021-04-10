using PEALSystem.Kimbemba.Models;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using PEALSystem.Kimbemba.SeedWorks;
using PEALSystem.Kimbemba.Servicos.Interfaces;
using PEALSystem.Kimbemba.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Servicos
{
    public class CodigoBarraServico : ICodigoBarraServico
    {
        private readonly ICodigoBarraRepositorio _codigoBarraRepositorio;
        private readonly IUnitOfWork _uOw;

        public CodigoBarraServico(ICodigoBarraRepositorio codigoBarraRepositorio, IUnitOfWork uOw)
        {
            _codigoBarraRepositorio = codigoBarraRepositorio;
            _uOw = uOw;
        }

        public async Task<Resultado> Gerar(GerarCodigoBarraViewModel obj)
        {
            int count = await _codigoBarraRepositorio.BuscarUltimoNumeroPorData(obj.Data);
            for (int i = 1; i <= obj.Quantidade; i++)
            {
                var random = new Random();
                long valor = random.Next(1000000000);

                string codigo = valor.ToString("0000000000000"),
                    codigoAEN = codigo;

                if (await Existe(codigo) || await Existe(codigoAEN))
                {
                    obj.Quantidade++;
                    continue;
                }

                var codigoBarra = new CodigoBarra(codigo, codigoAEN, ++count, obj.Data);

                if (!codigoBarra.IsValid) return new Resultado(false, "Não foi possível gerar os códigos de barra.");

                await _codigoBarraRepositorio.Inserir(codigoBarra);

            }

            if (await _uOw.Commit()) return new Resultado(true, "Códigos de barra gerados com sucesso.");
            else await _uOw.Rollback();

            return new Resultado(false, "Não foi possível gerar os códigos de barra.");
        }


        public async Task<Resultado> Remover(CodigoBarra obj)
        {
            _codigoBarraRepositorio.Remover(obj);
            if (await _uOw.Commit()) return new Resultado(true, "Código de barra removido com sucesso.");
            else await _uOw.Rollback();

            return new Resultado(false, "Não foi possível remover o código de barra.");
        }


        public async Task<Resultado> RemoverTodos()
        {
            var todosCodigosBarra = await ListarTodos();

            foreach (var item in todosCodigosBarra)
            {
                _codigoBarraRepositorio.Remover(item);
            }

            if (await _uOw.Commit()) return new Resultado(true, "Todos Códigos de barra removido com sucesso.");
            else await _uOw.Rollback();

            return new Resultado(false, "Não foi possível remover os códigos de barra.");
        }

        public async Task<ICollection<CodigoBarra>> ListarTodos()
        {
            return await _codigoBarraRepositorio.ListarTodos();
        }

        public Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null)
        {
            return _codigoBarraRepositorio.Listar(predicate);
        }

        public async Task<CodigoBarra> BuscarPorCodigo(string codigo)
        {
            return await _codigoBarraRepositorio.BuscarPorCodigo(codigo);
        }

        public async Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN)
        {
            return await _codigoBarraRepositorio.BuscarPorCodigoAEN(codigoAEN);
        }

        private async Task<bool> Existe(string codigo)
        {
            if (await BuscarPorCodigo(codigo) != null || await BuscarPorCodigoAEN(codigo) != null) return true;

            return false;
        }

    }
}
