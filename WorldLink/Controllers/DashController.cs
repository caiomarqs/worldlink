using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Repositories;

namespace WorldLink.Controllers
{
    public class DashController : Controller
    {

        private IContatoRepository _contatoRepository;

        public DashController(IContatoRepository contatoUsuarioRepository)
        {
            _contatoRepository = contatoUsuarioRepository;
        }


        public IActionResult Index()
        {
            var contatos = _contatoRepository.ListAll();
            return View(contatos);
        }

        [HttpPost]
        public IActionResult Filtar(string email)
        {
            var contatosFiltrados = _contatoRepository.Query(
                contato => contato.Nome.Contains(email)
            );

            if (contatosFiltrados.Count == 0)
            {
                return RedirectToAction("Index");
            }

            return View("Index", contatosFiltrados);
        }
    }
}
