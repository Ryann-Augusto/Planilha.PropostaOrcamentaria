using md_Planilha;
using Planilha1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleEstoque.Web.Controllers
{
    public class ContaController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            
            var achou = new ValidaUsuario().ValidarUsuario(login.Usuario, login.Senha);
            var usuario = mdUsuario.ObterCodigo(login.Usuario);

            if (achou)
            {
                if(usuario.NivelUsuario == 2)
                {
                FormsAuthentication.SetAuthCookie(login.Usuario, false);
                    Session["Usuario"] = login.Usuario;
                    Session["Codigo"] = usuario.CodigoUsuario;
                    return Redirect("/home");
                }
                else if (usuario.NivelUsuario == 1)
                {
                    FormsAuthentication.SetAuthCookie(login.Usuario, false);
                    return Redirect("/cadastrar");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login inválido.");
            }

            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Cadastrar()
        {
            ViewBag.Usuarios = new mdUsuario().ObterUsuarios();
            return View();
        }

        [HttpPost]
        public void Cadastro()
        {
            var Nome = Request["nome"];
            var Senha = Request["senha"];
            var ConfirmSenha = Request["confirmsenha"];
            var Nivel = Request["cargo"];

            if (Senha == ConfirmSenha)
            {
                if (Nivel == "vazio")
                {
                    TempData["erro"] = "Escolha um cargo";
                    Response.Redirect("/conta/cadastrar");
                }
                else
                {
                    TempData["sucesso"] = "Usuário cadastrado com sucesso.";
                    Response.Redirect("/conta/cadastrar");
                }
            }
            else
            {
                TempData["erro"] = "Atenção! As senhas não estão iguais.";
                Response.Redirect("/conta/cadastrar");
            }   
        }
    }
}