using EscolaProject.DATA.Interfaces;
using EscolaProject.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProject.DATA.Repositories
{
    public class RepositoryNotas : RepositoryBase<Notas>, IRepositoryNotas
    {
        public RepositoryNotas(bool _SaveChanges = true) : base(_SaveChanges)
        {


        }
    }
}
