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
    public class PortifolioPromovidoController : Controller
    { 
           private readonly IAppPortifolioPromovidoServico _portifolioromovidoApp;

        public PortifolioPromovidoController(IAppPortifolioPromovidoServico servico)
        {
            this._portifolioromovidoApp = servico;
        }

        //
        // GET: /PortifolioPromovido/
        public ActionResult Index()
        {
            var PortifolioPromovidoViewModel = Mapper.Map<IEnumerable<PortifolioPromovido>, IEnumerable<PortifolioPromovidoViewModel>>(this._portifolioromovidoApp.RecuperarTodos());

            ViewBag.PlanoId = new SelectList(PortifolioPromovidoViewModel, "PortifolioPromovidoId", "Nome");

            return View(PortifolioPromovidoViewModel);
        }

        //
        // GET: /PortifolioPromovido/Details/5
        public ActionResult Details(int id)
        {
            var portifolioPromovido = _portifolioromovidoApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<PortifolioPromovido, PortifolioPromovidoViewModel>(portifolioPromovido);
            return View(clienteViewModel);
        }

        //
        // GET: /PortifolioPromovido/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /PortifolioPromovido/Create
        [HttpPost]
        public ActionResult Create(PortifolioPromovidoViewModel portifolioPromovido)
        {
            try
            {
                var PortifolioPromovidoDominio = Mapper.Map<PortifolioPromovidoViewModel, PortifolioPromovido>(portifolioPromovido);
                this._portifolioromovidoApp.Add(PortifolioPromovidoDominio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //
        // GET: /PortifolioPromovido/Edit/5
         [HttpGet]
        public ActionResult Alterar(int id)
        {
           
            var PortifolioPromovido = this._portifolioromovidoApp.RecuperarPorId(id);
            var planoViewModel = Mapper.Map<PortifolioPromovido, PortifolioPromovidoViewModel>(PortifolioPromovido);
            return View(planoViewModel);
        }

        //
         // POST: /PortifolioPromovido/Edit/5
        [HttpPost]
         public ActionResult Alterar(PortifolioPromovidoViewModel portifolioPromovido)
        {

            if (ModelState.IsValid)
            {
                var portifolioPromovidoDominio = Mapper.Map<PortifolioPromovidoViewModel, PortifolioPromovido>(portifolioPromovido);
                this._portifolioromovidoApp.Update(portifolioPromovidoDominio);
                return RedirectToAction("Index");
           
            }
                
                return View();
          
        }

       //
        // GET: /PortifolioPromovido/Delete/5
        public ActionResult Delete(int id)
        {
            var portifolioPromovido = _portifolioromovidoApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<PortifolioPromovido, PortifolioPromovidoViewModel>(portifolioPromovido);
            return View(clienteViewModel);
        }

        //
        // POST: /PortifolioPromovido/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var portifolioPromovido = _portifolioromovidoApp.RecuperarPorId(id);
            _portifolioromovidoApp.Remove(portifolioPromovido);
            return RedirectToAction("Index");
        }        
    }         
}
