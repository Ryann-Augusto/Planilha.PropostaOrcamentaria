using md_Planilha;
using Planilha1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleEstoque.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
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

            var usuario = mdUsuario.ObterCodigo(login.Email);
            Session["Usuario"] = usuario.NomeUsuario;
            Session["Codigo"] = usuario.CodigoUsuario;

            Hash hash = new Hash(SHA256.Create());
            var senhaEncrip = hash.CriptografarSenha(login.Senha);

            var situacao = mdUsuario.situacao(usuario.CodigoUsuario);
            var achou = new ValidaUsuario().ValidarUsuario(login.Email, senhaEncrip);

            if (achou)
            {
                if (usuario.NivelUsuario == 2 && situacao.SituacaoUsuario == 1)
                {
                    var tiket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                        1, login.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, "Funcionario"));
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, tiket);
                    Response.Cookies.Add(cookie);
                    return Redirect("/home");
                }
                else if (usuario.NivelUsuario == 1 && situacao.SituacaoUsuario == 1)
                {
                    var tiket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                        1, login.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, "Administrador"));
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, tiket);
                    Response.Cookies.Add(cookie);
                    return Redirect("/cadastrar");
                }
                else if (situacao.SituacaoUsuario == 0)
                {
                    ModelState.AddModelError("", "Usuário Bloqueado!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login inválido.");
            }

            return View(login);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cadastrar()
        {
            ViewBag.Usuarios = new mdUsuario().ObterUsuarios();
            return View();
        }

        [HttpPost]
        public void Cadastro()
        {
            var Nome = Request["nome"];
            var Email = Request["email"];
            var Senha = Request["senha"];
            int Nivel = Convert.ToInt32(Request["cargo"]);

            Hash hash = new Hash(SHA256.Create());
            var senhaEncrip = hash.CriptografarSenha(Senha);

            if (Nivel == 0)
            {
                TempData["erro"] = "Escolha um cargo";
                Response.Redirect("/conta/cadastrar");
            }
            else
            {
                var Existente = new ValidaUsuario().UsuarioExistente(Email);
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
                        Usuario.CadUsuario(Nome, Email, senhaEncrip, Nivel);
                        TempData["sucesso"] = "Usuário cadastrado com sucesso.";
                        Response.Redirect("/conta/cadastrar");
                    }
                    else
                    {
                        Usuario.CadUsuario(Nome, Email, senhaEncrip, Nivel);
                        var Cod = mdUsuario.ObterCodigo(Email);
                        Usuario.CriarTabelas(Cod.CodigoUsuario);
                        TempData["sucesso"] = "Usuário cadastrado com sucesso.";
                        Response.Redirect("/conta/cadastrar");
                    }
                }
            }
        }

        public ActionResult AlterarUsuario(int id)
        {
            ViewBag.Editar = mdUsuario.BuscarUsuId(id);
            return View();
        }

        [HttpPost]
        public void ModificarUsuario(int id)
        {
            var Alterar = new mdUsuario();
            var Usuario = new mdValores();
            Usuario.NomeUsuario = Request["nome"].ToString();
            Usuario.EmailUsuario = Request["email"].ToString();
            Usuario.SenhaUsuario = Request["senha"].ToString();
            Usuario.ConfirmSenhaUsuario = Request["confirmsenha"].ToString();

            Hash hash = new Hash(SHA256.Create());
            var senhaEncrip = hash.CriptografarSenha(Usuario.SenhaUsuario);

            if (Usuario.SenhaUsuario != Usuario.ConfirmSenhaUsuario)
            {
                TempData["erro"] = "Atenção! As senhas não estão iguais.";
                Response.Redirect("/conta/cadastrar");
            }
            else if (Usuario.SenhaUsuario == string.Empty && Usuario.ConfirmSenhaUsuario == string.Empty)
            {
                Alterar.AlterarNomeEmail(id, Usuario.NomeUsuario, Usuario.EmailUsuario);
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
                Alterar.AlterarTudo(id, Usuario.NomeUsuario, Usuario.EmailUsuario, senhaEncrip);
                TempData["sucesso"] = "Nome e senha de usuário alterado com sucesso.";
                Response.Redirect("/conta/cadastrar");
            }
        }

        public void ApagarUsuario(int id)
        {
            var Apagar = new mdUsuario();
            var Editar = mdUsuario.BuscarUsuId(id);
            if (Editar.NivelUsuario == 1)
            {
                Apagar.ApagarUsuario(id);
                TempData["sucesso"] = "Usuario Excluido!";
                Response.Redirect("/conta/cadastrar");
            }
            else
            {
                Apagar.ApagarTabelas(id);
                Apagar.ApagarUsuario(id);
                TempData["sucesso"] = "Usuario Excluido!";
                Response.Redirect("/conta/cadastrar");
            }
        }
        public void BloquearUsuario(int id)
        {
            var situacao = mdUsuario.situacao(id);
            var blockUnlok = new mdUsuario();
            ViewBag.situacao = situacao.SituacaoUsuario;
            if (situacao.SituacaoUsuario == 1)
            {
                var Sit = 0;
                blockUnlok.BloquearDesbloquear(id, Sit);
                TempData["sucesso"] = "Usuario Bloqueado!";
            }
            else if (situacao.SituacaoUsuario == 0)
            {
                TempData["sucesso"] = "Usuario desbloqueado!";
                var Sit = 1;
                blockUnlok.BloquearDesbloquear(id, Sit);
            }
            else
            {
                TempData["erro"] = "Não foi possivel alterar!";
            }
            Response.Redirect("/conta/cadastrar");

        }
    }
}