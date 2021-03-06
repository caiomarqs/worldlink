﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Models;
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

            //Verificação de login
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
            {
                ViewBag.userId = HttpContext.Session.GetString("userId");

                var contatos = _contatoRepository.ListAll();
                return View(contatos);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Filtar(string email)
        {
            ViewBag.userId = HttpContext.Session.GetString("userId");
            TempData["searchFlag"] = true;

            var contatosFiltrados = _contatoRepository.Query(
                contato => contato.Email.Contains(email)
            );

            if (contatosFiltrados.Count == 0)
            {
                return View("Index", null);
            }

            return View("Index", contatosFiltrados);
        }

        [HttpPost]
        public IActionResult Remover(int id) 
        {
            _contatoRepository.Remove(id);
            _contatoRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
