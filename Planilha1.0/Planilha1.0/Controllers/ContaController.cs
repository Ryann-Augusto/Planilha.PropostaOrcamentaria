﻿using md_Planilha;
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
            int Nivel = Convert.ToInt32(Request["cargo"]);

            if (Senha == ConfirmSenha)
            {
                if (Nivel == 0)
                {
                    TempData["erro"] = "Escolha um cargo";
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
            else
            {
                TempData["erro"] = "Atenção! As senhas não estão iguais.";
                Response.Redirect("/conta/cadastrar");
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
            var Usuario = new mdJaneiro();
            Usuario.NomeUsuario = Request["nome"].ToString();
            Usuario.SenhaUsuario = Request["senha"].ToString();
            Usuario.ConfirmSenhaUsuario = Request["confirmsenha"].ToString();

            if (Usuario.SenhaUsuario != Usuario.ConfirmSenhaUsuario)
            {
                TempData["erro"] = "Atenção! As senhas não estão iguais.";
                Response.Redirect("/conta/cadastrar");
            }
            else
            {
                var Alterar = new mdUsuario();
                Alterar.Alterar(id, Usuario.NomeUsuario, Usuario.SenhaUsuario);
                TempData["sucesso"] = "Usuário alterado com sucesso.";
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