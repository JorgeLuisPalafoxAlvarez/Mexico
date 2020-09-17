using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mexico.Models;

namespace Mexico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            mexicoContext context = new mexicoContext();
            var estados = context.Estados.OrderBy(x => x.Nombre).ToList();

            return View(estados);
        }
    }
}