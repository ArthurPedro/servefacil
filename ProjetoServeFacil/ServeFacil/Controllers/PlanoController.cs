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
    public class PlanoController : Controller
    {
        private readonly IAppPlanoServico _planoApp;

        public PlanoController(IAppPlanoServico servico)
        {
            this._planoApp = servico;
        }

        //
        // GET: /Plano/
        public ActionResult Index()
        {
            var planoViewModel = Mapper.Map<IEnumerable<Plano>, IEnumerable<PlanoViewModel>>(this._planoApp.RecuperarTodos());

            ViewBag.PlanoId = new SelectList(planoViewModel, "PlanoId", "Nome");

            return View(planoViewModel);
        }

        //
        // GET: /Plano/Details/5
        public ActionResult Details(int id)
        {
            var plano = _planoApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Plano, PlanoViewModel>(plano);
            return View(clienteViewModel);
        }

        //
        // GET: /Plano/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Plano/Create
        [HttpPost]
        public ActionResult Create(PlanoViewModel plano)
        {
            try
            {
                var planoDominio = Mapper.Map<PlanoViewModel, Plano>(plano);
                this._planoApp.Add(planoDominio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //
        // GET: /Plano/Edit/5
         [HttpGet]
        public ActionResult Alterar(int id)
        {
           
            var plano = this._planoApp.RecuperarPorId(id);
            var planoViewModel = Mapper.Map<Plano, PlanoViewModel>(plano);
            return View(planoViewModel);
        }

        //
         // POST: /Plano/Edit/5
        [HttpPost]
         public ActionResult Alterar(PlanoViewModel plano)
        {

            if (ModelState.IsValid)
            {
                var planoDominio = Mapper.Map<PlanoViewModel, Plano>(plano);
                this._planoApp.Update(planoDominio);
                return RedirectToAction("Index");
           
            }
                
                return View();
          
        }

       //
        // GET: /Plano/Delete/5
        public ActionResult Delete(int id)
        {
            var plano = _planoApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Plano, PlanoViewModel>(plano);
            return View(clienteViewModel);
        }

        //
        // POST: /Plano/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var plano = _planoApp.RecuperarPorId(id);
            _planoApp.Remove(plano);
            return RedirectToAction("Index");
        }        
    }
}
