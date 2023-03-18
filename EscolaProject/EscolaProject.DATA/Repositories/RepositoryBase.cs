using EscolaProject.DATA.Interfaces;
using EscolaProject.DATA.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProject.DATA.Repositories
{

    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected escolaContext _escolaContext;
        public bool _SaveChanges = true;

        public RepositoryBase(bool savechanges = true) {
            _SaveChanges = savechanges;
            _escolaContext = new escolaContext();
        }

        public T Alterar(T objeto)
        {
            _escolaContext.Entry(objeto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            if (_SaveChanges)
            {
                _escolaContext.SaveChanges();
            }

            return objeto;
        }

        public void Dispose()
        {
            _escolaContext.Dispose();
        }

        public void Excluir(T objeto)
        {
            _escolaContext.Set<T>().Remove(objeto);
            if (_SaveChanges)
            {
                _escolaContext.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPorId(variavel);
            Excluir(obj);   

        }

        public T Incluir(T objeto)
        {
            _escolaContext.Set<T>().Add(objeto);
            if (_SaveChanges)
            {
                _escolaContext.SaveChanges();
            }
            return objeto;
            
        }

        public void SaveChanges()
        {
            _escolaContext.SaveChanges();
        }

        public T SelecionarPorId(params object[] variavel)
        {
            return _escolaContext.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _escolaContext.Set<T>().ToList();
        }
    }

}
