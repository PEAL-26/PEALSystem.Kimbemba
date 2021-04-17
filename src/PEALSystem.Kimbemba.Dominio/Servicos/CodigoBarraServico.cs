using PEALSystem.Kimbemba.Dominio.Dtos;
using PEALSystem.Kimbemba.Dominio.Entidades;
using PEALSystem.Kimbemba.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Dominio.Servicos
{
    public class CodigoBarraServico : ICodigoBarraServico
    {
        private readonly ICodigoBarraRepositorio _codigoBarraRepositorio;

        public CodigoBarraServico(ICodigoBarraRepositorio codigoBarraRepositorio)
        {
            _codigoBarraRepositorio = codigoBarraRepositorio;
        }

        public async Task<CodigoBarra> Gerar(GerarCodigoBarra obj)
        {
            int count = await _codigoBarraRepositorio.BuscarUltimoNumeroPorData(obj.Data);
            var codigoBarra = new CodigoBarra();
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

                codigoBarra = new CodigoBarra(codigo, codigoAEN, ++count, obj.Data);

                if (!codigoBarra.IsValid) return codigoBarra;

                await _codigoBarraRepositorio.Inserir(codigoBarra);

            }

            return codigoBarra;
        }


        public CodigoBarra Remover(CodigoBarra obj)
        {
            _codigoBarraRepositorio.Remover(obj);

            return obj;
        }


        public async Task<CodigoBarra> RemoverTodos()
        {
            var todosCodigosBarra = await ListarTodos();
            var codigoBarra = new CodigoBarra();
            foreach (var item in todosCodigosBarra)
            {
                _codigoBarraRepositorio.Remover(item);
                codigoBarra = item;
            }

            return codigoBarra;
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
