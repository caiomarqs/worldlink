using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Models;
using WorldLink.Repositories;

namespace WorldLink.Controllers
{
    public class LoginController : Controller
    {

        private IUsuarioRepository _repository;


        public LoginController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {

            //Verificação de login
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
            {
                return RedirectToAction("Index", "Dash");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var hasUsuario = _repository.FindByNome(usuario.Nome);
            


            if (hasUsuario != null)
            {
                var senhaTest = BCrypt.Net.BCrypt.Verify(usuario.Senha, hasUsuario.Senha);

                if (senhaTest)
                {

                    SetSession(hasUsuario);
                    return RedirectToAction("Index", "Dash");
                }
                else
                {
                    TempData["msg"] = "A senha está errada!";
                }
            }
            else
            {
                TempData["msg"] = "Usuário inexistente!";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            ClearSession();
            return RedirectToAction("Index");
        }


        public void SetSession(Usuario usuario)
        {
            HttpContext.Session.SetString("userId", usuario.UsuarioId.ToString());
            ViewBag.userId = usuario.UsuarioId.ToString();
        }

        public void ClearSession()
        {
            HttpContext.Session.SetString("userId", "");
            ViewBag.userId = null;
        }

    }

}