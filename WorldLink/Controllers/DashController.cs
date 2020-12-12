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
            var contatosUsuarios = _contatoRepository.ListAll();
            return View(contatosUsuarios);
        }
    }
}
