using EscolaProject.DATA.Models;
using EscolaProject.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EscolaProject.WEB.Controllers
{
    public class AlunoController : Controller
    {
        private RepositoryAluno repositoryAluno = new RepositoryAluno();
        private RepositoryMateria repositoryMateria = new RepositoryMateria();
        private RepositoryMateriaAluno repositoryMateriaAluno = new RepositoryMateriaAluno();

        public IActionResult Index()
        {
            List<Aluno> oListAluno = repositoryAluno.SelecionarTodos();
            return View(oListAluno);
        }

        public IActionResult Create()
        {
            Aluno aluno = new Aluno();

            aluno.Materias = repositoryMateria.SelecionarTodos();

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Create(Aluno model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Aluno aluno = repositoryAluno.Incluir(model);

            if (model.Materias.Where(c => c.Selecionada).Any())
            {
                List<MateriaAluno> materiasAlunos = new List<MateriaAluno>();

                foreach (var item in model.Materias.Where(c => c.Selecionada))
                {
                    repositoryMateriaAluno.Incluir(new MateriaAluno()
                    {
                        IdAluno = aluno.Id,
                        IdMateria = item.Id
                    });
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(repositoryAluno.SelecionarPorId(id));
        }

        public IActionResult Edit(int id)
        {
            Aluno aluno = repositoryAluno.SelecionarPorId(
                    id: id,
                    includes: new string[]
                    {
                        nameof(Aluno.MateriasAlunos)
                    }
                );

            aluno.Materias = repositoryMateria.SelecionarTodos();

            foreach (var item in aluno.Materias)
            {
                item.Selecionada = aluno.MateriasAlunos.Where(c => c.IdMateria == item.Id)
                                                      .FirstOrDefault() != null ? true : false;
            }

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Edit(Aluno model)
        {
            Aluno oAluno = repositoryAluno.Alterar(model);

            int id = oAluno.Id;


            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            repositoryAluno.Excluir(id);
            return RedirectToAction("index");
        }
    }
}
