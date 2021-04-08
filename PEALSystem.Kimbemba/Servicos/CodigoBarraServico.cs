using PEALSystem.Kimbemba.Models;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using PEALSystem.Kimbemba.Servicos.Interfaces;
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

        public async Task Inserir(CodigoBarra obj)
        {
            await _codigoBarraRepositorio.Inserir(obj);
            await _uOw.Commit();
        }

        public async void Alterar(CodigoBarra obj)
        {
            _codigoBarraRepositorio.Alterar(obj);
            await _uOw.Commit();
        }


        public async Task GerarCodigoBarra(int qtd)
        {
            for (int i = 1; i <= qtd; i++)
            {
                string codigo = $"123456789{i}",
                    codigoAEN = $"123456789{i}";

                if ( await Existe(codigo) || await Existe(codigoAEN))
                {
                    qtd++;
                    continue;
                }

                var codigoBarra = new CodigoBarra(codigo, codigoAEN, i);
                await _codigoBarraRepositorio.Inserir(codigoBarra);
            }

            if (!await _uOw.Commit()) 
                await _uOw.Rollback();
        }

        public async void Remover(CodigoBarra obj)
        {
            _codigoBarraRepositorio.Remover(obj);
            await _uOw.Commit();
        }

        public async Task<ICollection<CodigoBarra>> ListarTodos()
        {
            return await _codigoBarraRepositorio.ListarTodos();
        }

        public Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null)
        {
            return _codigoBarraRepositorio.Listar(predicate);
        }

        public async Task<CodigoBarra> BuscarPorId(int id)
        {
            return await _codigoBarraRepositorio.BuscarPorId(id);
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
