using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ServeFacil.Aplicacao.Apps;
using ServeFacil.Dominio.Entidades;
using ServeFacil.ViewModels;
using System.Linq;

namespace ServeFacil.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IAppUsuarioServico _usuarioApp;

        public UsuarioController(IAppUsuarioServico servico)
        {
            this._usuarioApp = servico;
        }

         //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel usuario)
        {
            // Vê se o usuario é valido e traça um map para jogar o objeto recebido da view para o AppUsuarioServico.

            try
            {
                var usuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                var busca = this._usuarioApp.RecuperarPorLogin(usuarioDominio);

                if (busca != null)
                {
                    Session["UsuarioLogadoID"] = busca.UsuarioId;
                    Session["UsuarioLogadoNome"] = busca.Nome;

                    var s = Convert.ToString(Session["UsuarioLogadoNome"]);
                    string[] nome = s.Split(' ');
                    Session["UsuarioPrimeiroNome"] = nome.First();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                string loginOuSenhaIncorreto = "Usuario ou senha incorreto!";
                Session["LoginOuSenhaIncorreto"] = loginOuSenhaIncorreto;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Descupe erro, Contate o Administrador");
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Usuario/
        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(this._usuarioApp.RecuperarTodos());

            ViewBag.UsuarioId = new SelectList(usuarioViewModel, "UsuarioId", "Nome");

            return View(usuarioViewModel);
        }

        //
        // GET: /Usuarios/Details/5
        public ActionResult Details(int id)
        {
            var usuario = _usuarioApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            return View(clienteViewModel);
        }

        //
        // GET: /Usuario/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                var usuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                this._usuarioApp.Add(usuarioDominio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //
        // GET: /Usuario/Edit/5
         [HttpGet]
        public ActionResult Alterar(int id)
        {

            if (Session["UsuarioLogadoID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            var uID = Convert.ToInt32(Session["UsuarioLogadoID"]);
            var usuarioDominio = Mapper.Map<Usuario, UsuarioViewModel>(this._usuarioApp.RecuperarPorId(uID));


            return View(usuarioDominio);
        }

        //
        // POST: /Usuario/Edit/5
        [HttpPost]
        public ActionResult Alterar(UsuarioViewModel usuario)
        {

            if (ModelState.IsValid)
            {     
                var usuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                this._usuarioApp.Update(usuarioDominio);
                return RedirectToAction("Index");
           
            }
                
                return View();
          
        }

       //
        // GET: /Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioApp.RecuperarPorId(id);
            var clienteViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            return View(clienteViewModel);
        }

        //
        // POST: /Usuario/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuario = _usuarioApp.RecuperarPorId(id);
            _usuarioApp.Remove(usuario);
            return RedirectToAction("Index");
        }
        }
    }
