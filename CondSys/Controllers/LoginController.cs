using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondSys.DAO;
using CondSys.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CondSys.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = new UsuarioDao().Autenticar(usuario);
                if (result)
                    return RedirectToAction("Index", "Assembleia");

                return View(usuario);
            }

            return View(usuario);
        }

        public IActionResult Logout()
        {
            UsuarioLogado.Usuario = null;
            return RedirectToAction("Index","Home");
        }
    }
}