using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers_AspNETCore.Models;

namespace EPlayers_AspNETCore.Controllers
{
    public class NoticiaController : Controller
    {

        Noticias noticiasModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }


        public IActionResult Cadastrar(IFormCollection form)
        {
        
        }

    }
}
