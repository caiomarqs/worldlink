using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Models;
using WorldLink.Repositories;

namespace WorldLink.Controllers
{
    public class HomeController : Controller
    {
        private IContatoRepository _repository;

        public HomeController(IContatoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Contato contato)
        {
            var hasEmail = _repository.FindByEmail(contato.Email);

            if (hasEmail == null)
            {
                _repository.Insert(contato);
                _repository.Save();

                TempData["success-msg"] = "Você está cadastrado para receber as novidades!";
            }
            else
            {
                TempData["error-msg"] = "Você já está cadastrado para receber as novidades! Fique tranquilo!";
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
