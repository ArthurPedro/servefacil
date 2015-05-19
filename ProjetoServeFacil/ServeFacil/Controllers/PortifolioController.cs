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
    public class PortifolioController : Controller
    { 
        private readonly IAppPortifolioServico _portifolioApp;

        public PortifolioController(IAppPortifolioServico servico)
        {
            this._portifolioApp = servico;
        }

        //
        // GET: /Portifolio/
        public ActionResult Index()
        {
            var portifolioViewModel = Mapper.Map<IEnumerable<Portifolio>, IEnumerable<PlanoViewModel>>(this._portifolioApp.RecuperarTodos());

            ViewBag.PortifolioId = new SelectList(portifolioViewModel, "PortifolioId", "Nome");

            return View(portifolioViewModel);
        }

        //
        // GET: /Portifolio/Details/5
        public ActionResult Details(int id)
        {
            var portifolio = _portifolioApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Portifolio, PortifolioViewModel>(portifolio);
            return View(clienteViewModel);
        }

        //
        // GET: /Portifolio/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Portifolio/Create
        [HttpPost]
        public ActionResult Create(PortifolioViewModel portifolio)
        {
            try
            {
                var portifolioDominio = Mapper.Map<PortifolioViewModel, Portifolio>(portifolio);
                this._portifolioApp.Add(portifolioDominio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //
        // GET: /Portifolio/Edit/5
         [HttpGet]
        public ActionResult Alterar(int id)
        {
           
            var portifolio = this._portifolioApp.RecuperarPorId(id);
            var portifolioViewModel = Mapper.Map<Portifolio, PortifolioViewModel>(portifolio);
            return View(portifolioViewModel);
        }

        //
         // POST: /Portifolio/Edit/5
        [HttpPost]
         public ActionResult Alterar(PortifolioViewModel portifolio)
        {

            if (ModelState.IsValid)
            {
                var planoDominio = Mapper.Map<PortifolioViewModel, Portifolio>(portifolio);
                this._portifolioApp.Update(planoDominio);
                return RedirectToAction("Index");
           
            }
                
                return View();
          
        }

       //
        // GET: /Portifolio/Delete/5
        public ActionResult Delete(int id)
        {
            var portifolio = _portifolioApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Portifolio, PortifolioViewModel>(portifolio);
            return View(clienteViewModel);
        }

        //
        // POST: /Portifolio/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var portifolio = _portifolioApp.RecuperarPorId(id);
            _portifolioApp.Remove(portifolio);
            return RedirectToAction("Index");
        }        
    }          
}
