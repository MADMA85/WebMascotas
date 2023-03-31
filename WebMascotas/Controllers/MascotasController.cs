using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using WebMascotas.Models;

using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebMascotas.Controllers
{
    public class MascotasController : Controller
    {
        private readonly IConfiguration _configuration;
        string connString;
        public MascotasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        List<Mascota> mascotas = new List<Models.Mascota>();

        public IActionResult Index()
        {
            List<Mascota> _mascotas = new List<Mascota>();
            CRUD crud = new CRUD();
            _mascotas = crud.GetMascota();
            return View(_mascotas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Mascota mascota = new Models.Mascota();

            return View(mascota);
        }
        [HttpPost]
        public IActionResult Create(Models.Mascota? mascota)
        {
            List<Mascota> _mascotas = new List<Mascota>();
            CRUD crud = new CRUD();
            bool bAdd = crud.AddMascota(mascota);

            if (bAdd)
                return RedirectToAction("Index");
            else
            {
                return (IActionResult)Results.BadRequest();
            }
        }
    }
}