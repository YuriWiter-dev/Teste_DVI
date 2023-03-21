using EscolaProject.DATA.Models;
using EscolaProject.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EscolaProject.WEB.Controllers
{
    public class MateriaController : Controller
    {
        private RepositoryMateria repositoryMateria = new RepositoryMateria();

        public IActionResult Index()
        {
            List<Materia> oListMateria = repositoryMateria.SelecionarTodos();
            return View(oListMateria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Materia model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            repositoryMateria.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(repositoryMateria.SelecionarPorId(id));
        }

        public IActionResult Edit(int id)
        {
            return View(repositoryMateria.SelecionarTodos());
        }

        [HttpPost]
        public IActionResult Edit(Materia model)
        {
            Materia oMateria = repositoryMateria.Alterar(model);

            int id = oMateria.Id;


            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            repositoryMateria.Excluir(id);
            return RedirectToAction("index");
        }

    }
}
