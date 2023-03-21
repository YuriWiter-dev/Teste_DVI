using EscolaProject.DATA.Interfaces;
using EscolaProject.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProject.DATA.Repositories
{
    public class RepositoryMateriaAluno : RepositoryBase<MateriaAluno>, IRepositoryMateriaAluno
    {
        public RepositoryMateriaAluno(bool _SaveChanges = true) : base(_SaveChanges)
        {


        }
    }
}