using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ServeFacil.Aplicacao.Apps;
using ServeFacil.Dominio.Entidades;
using ServeFacil.ViewModels;
using ServeFacil.Aplicacao.Interfaces;

namespace ServeFacil.Controllers
{
    public class CategoriaController : Controller
    {
     private readonly IAppCategoriaServico _categoriaApp;

     public CategoriaController(IAppCategoriaServico servico)
        {
            this._categoriaApp = servico;
        }

        //
     // GET: /Categoria/
        public ActionResult Index()
        {
            var categoriaViewModel = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(this._categoriaApp.RecuperarTodos());

            ViewBag.CategoriaId = new SelectList(categoriaViewModel, "CategoriaId", "Nome");

            return View(categoriaViewModel);
        }

        //
        // GET: /Categoria/Details/5
        public ActionResult Details(int id)
        {
            var categoria = _categoriaApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(clienteViewModel);
        }

        //
        // GET: /Categoria/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Categoria/Create
        [HttpPost]
        public ActionResult Create(CategoriaViewModel categoria)
        {
            try
            {
                var categoriaDominio = Mapper.Map<CategoriaViewModel, Categoria>(categoria);
                this._categoriaApp.Add(categoriaDominio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //
        // GET: /Categoria/Edit/5
         [HttpGet]
        public ActionResult Alterar(int id)
        {
           
            var categoria = this._categoriaApp.RecuperarPorId(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(categoriaViewModel);
        }

        //
         // POST: /Categoria/Edit/5
        [HttpPost]
         public ActionResult Alterar(CategoriaViewModel categoria)
        {

            if (ModelState.IsValid)
            {
                var categoriaDominio = Mapper.Map<CategoriaViewModel, Categoria>(categoria);
                this._categoriaApp.Update(categoriaDominio);
                return RedirectToAction("Index");
           
            }
                
                return View();
          
        }

       //
        // GET: /Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = _categoriaApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(clienteViewModel);
        }

        //
        // POST: /Categoria/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var categoria = _categoriaApp.RecuperarPorId(id);
            _categoriaApp.Remove(categoria);
            return RedirectToAction("Index");
        }
        }
}
