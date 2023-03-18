using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProject.DATA.Interfaces
{
    public interface IRepositoryModel<T> where T : class 
    {
        List<T> SelecionarTodos();
        T SelecionarPorId( params object[] variavel);

        T Incluir(T objeto);

        void Excluir(T objeto);

        void Excluir(params object[] variavel);

        void SaveChanges();
        T Alterar(T objeto);
    }
}
