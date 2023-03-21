using EscolaProject.DATA.Models;
using EscolaProject.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EscolaProject.WEB.Controllers
{
    public class NotasController : Controller
    {
        private RepositoryNotas repositoryNotas = new RepositoryNotas();
        private RepositoryAluno repositoryAluno = new RepositoryAluno();
        private RepositoryMateria repositoryMateria = new RepositoryMateria();

        public IActionResult Index()
        {
            List<Notas> oListNotas = repositoryNotas.SelecionarTodos();
            return View(oListNotas);
        }

        public IActionResult Create()
        {
            Notas notas = new Notas();

            notas.Alunos = repositoryAluno.SelecionarTodos();
            notas.Materias = repositoryMateria.SelecionarTodos();

            return View(notas);
        }

        [HttpPost]
        public IActionResult Create(Notas model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            repositoryNotas.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(repositoryNotas.SelecionarTodos());
        }

        public IActionResult Edit(int id)
        {
            return View(repositoryNotas.SelecionarTodos());
        }

        [HttpPost]
        public IActionResult Edit(Notas model)
        {
            Notas oNotas = repositoryNotas.Alterar(model);

            int id = oNotas.Id;


            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            repositoryNotas.Excluir(id);
            return RedirectToAction("index");
        }

    }
}
