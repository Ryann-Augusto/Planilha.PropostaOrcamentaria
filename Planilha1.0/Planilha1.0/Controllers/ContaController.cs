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
                if (usuario.NivelUsuario == 2)
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
            int Nivel = Convert.ToInt32(Request["cargo"]);


            if (Nivel == 0)
            {
                TempData["erro"] = "Escolha um cargo";
                Response.Redirect("/conta/cadastrar");
            }
            else
            {
                var Existente = new ValidaUsuario().UsuarioExistente(Nome);
                if (Existente)
                {
                    TempData["erro"] = "Atenção! Esse usuário já existe.";
                    Response.Redirect("/conta/cadastrar");
                }
                else
                {
                    var Usuario = new mdUsuario();
                    if (Nivel == 1)
                    {
                        Usuario.CadUsuario(Nome, Senha, Nivel);
                        TempData["sucesso"] = "Usuário cadastrado com sucesso.";
                        Response.Redirect("/conta/cadastrar");
                    }
                    else
                    {
                        Usuario.CadUsuario(Nome, Senha, Nivel);
                        var Cod = mdUsuario.ObterCodigo(Nome);
                        Usuario.CriarTabelas(Cod.CodigoUsuario);
                        TempData["sucesso"] = "Usuário cadastrado com sucesso.";
                        Response.Redirect("/conta/cadastrar");
                    }
                }
            }
        }

        [AllowAnonymous]
        public ActionResult Editar(int id)
        {
            ViewBag.Editar = mdUsuario.BuscarUsuId(id);
            return View();
        }

        [HttpPost]
        public void Alterar(int id)
        {
            var Alterar = new mdUsuario();
            var Usuario = new mdValores();
            Usuario.NomeUsuario = Request["nome"].ToString();
            Usuario.SenhaUsuario = Request["senha"].ToString();
            Usuario.ConfirmSenhaUsuario = Request["confirmsenha"].ToString();

            if (Usuario.SenhaUsuario != Usuario.ConfirmSenhaUsuario)
            {
                TempData["erro"] = "Atenção! As senhas não estão iguais.";
                Response.Redirect("/conta/cadastrar");
            }
            else if (Usuario.SenhaUsuario == string.Empty && Usuario.ConfirmSenhaUsuario == string.Empty)
            {
                Alterar.AlterarNome(id, Usuario.NomeUsuario);
                TempData["sucesso"] = "Nome de usuário alterado com sucesso.";
                Response.Redirect("/conta/cadastrar");
            }
            else if (Usuario.SenhaUsuario.Trim().Length < 6)
            {
                TempData["erro"] = "Atenção! A senha não pode ser menor que 6!";
                Response.Redirect("/conta/cadastrar");
            }
            else
            {
                Alterar.AlterarTudo(id, Usuario.NomeUsuario, Usuario.SenhaUsuario);
                TempData["sucesso"] = "Nome e senha de usuário alterado com sucesso.";
                Response.Redirect("/conta/cadastrar");
            }
        }

        public void Apagar(int id)
        {
            var Apagar = new mdUsuario();
            var Editar = mdUsuario.BuscarUsuId(id);
            if (Editar.NivelUsuario == 1)
            {
                Apagar.ApagarUsuario(id);
                Response.Redirect("/conta/cadastrar");
            }
            else
            {
                Apagar.ApagarTabelas(id);
                Apagar.ApagarUsuario(id);
                Response.Redirect("/conta/cadastrar");
            }
        }
    }
}