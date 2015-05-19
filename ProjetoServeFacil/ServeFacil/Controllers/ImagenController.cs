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
    public class ImagenController : Controller
    {
        private readonly IAppImagenServico _imagenApp;

        public ImagenController(IAppImagenServico servico)
        {
            this._imagenApp = servico;
        }

        //
        // GET: /Imagen/
        public ActionResult Index()
        {
            var imagenViewModel = Mapper.Map<IEnumerable<Imagen>, IEnumerable<ImagensViewModel>>(this._imagenApp.RecuperarTodos());

            ViewBag.ImagenId = new SelectList(imagenViewModel, "ImagenId", "Nome");

            return View(imagenViewModel);
        }

        //
        // GET: /Imagen/Details/5
        public ActionResult Details(int id)
        {
            var imagen = _imagenApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Imagen, ImagensViewModel>(imagen);
            return View(clienteViewModel);
        }

        //
        // GET: /Imagen/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Imagen/Create
        [HttpPost]
        public ActionResult Create(ImagensViewModel imagen)
        {
            try
            {
                var imagenDominio = Mapper.Map<ImagensViewModel, Imagen>(imagen);
                this._imagenApp.Add(imagenDominio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //
        // GET: /Imagen/Edit/5
         [HttpGet]
        public ActionResult Alterar(int id)
        {
           
            var imagen = this._imagenApp.RecuperarPorId(id);
            var imagenViewModel = Mapper.Map<Imagen, ImagensViewModel>(imagen);
            return View(imagenViewModel);
        }

        //
         // POST: /Imagen/Edit/5
        [HttpPost]
         public ActionResult Alterar(ImagensViewModel imagen)
        {

            if (ModelState.IsValid)
            {
                var imagenDominio = Mapper.Map<ImagensViewModel, Imagen>(imagen);
                this._imagenApp.Update(imagenDominio);
                return RedirectToAction("Index");
           
            }
                
                return View();
          
        }

       //
        // GET: /Imagen/Delete/5
        public ActionResult Delete(int id)
        {
            var imagen = _imagenApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Imagen, ImagensViewModel>(imagen);
            return View(clienteViewModel);
        }

        //
        // POST: /Imagen/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuario = _imagenApp.RecuperarPorId(id);
            _imagenApp.Remove(usuario);
            return RedirectToAction("Index");
        }
        }
}
