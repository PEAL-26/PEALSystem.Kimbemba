using PEALSystem.Kimbemba.Aplicacao.Intertfaces;
using PEALSystem.Kimbemba.Aplicacao.ViewModels;
using PEALSystem.Kimbemba.Dominio.Dtos;
using PEALSystem.Kimbemba.Dominio.Entidades;
using PEALSystem.Kimbemba.Dominio.Interfaces;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Aplicacao.Aplicacao
{
    public class CodigoBarraApp : ICodigoBarraApp
    {
        private readonly ICodigoBarraServico _codigoBarraServico;
        private readonly IUnitOfWork _uOw;

        public CodigoBarraApp(ICodigoBarraServico codigoBarraServico, IUnitOfWork uOw)
        {
            _codigoBarraServico = codigoBarraServico;
            _uOw = uOw;
        }

        public async Task<bool> Gerar(GerarCodigoBarraViewModel obj)
        {

            GerarCodigoBarra codigoBarra = new GerarCodigoBarra() { Quantidade = obj.Quantidade, Data = obj.Data };
            await _codigoBarraServico.Gerar(codigoBarra);

            if (await _uOw.Commit()) return true;
            else await _uOw.Rollback();

            return false;
        }


        public async Task<CodigoBarra> Remover(CodigoBarra obj)
        {
            _codigoBarraServico.Remover(obj);
            if (!await _uOw.Commit()) await _uOw.Rollback();

            return obj;
        }


        public async Task<bool> RemoverTodos()
        {

            await _codigoBarraServico.RemoverTodos();

            if (await _uOw.Commit()) return true;
            else await _uOw.Rollback();

            return false;
        }

        public async Task<ICollection<CodigoBarra>> ListarTodos()
        {
            return await _codigoBarraServico.ListarTodos();
        }

        public Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null)
        {
            return _codigoBarraServico.Listar(predicate);
        }

        public async Task<CodigoBarra> BuscarPorCodigo(string codigo)
        {
            return await _codigoBarraServico.BuscarPorCodigo(codigo);
        }

        public async Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN)
        {
            return await _codigoBarraServico.BuscarPorCodigoAEN(codigoAEN);
        }

    }
}
