using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondSys.DAO;
using CondSys.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CondSys.Controllers
{
    public class AssembleiaController : Controller
    {
        public readonly AssembleiaDao AssembleiaDao;

        public AssembleiaController(AssembleiaDao dao)
        {
            AssembleiaDao = dao;

        }
        public IActionResult Index()
        {
            var assemblea = new AssembleiaViewModel();
            assemblea.Assembleias = AssembleiaDao.List();
            return View(assemblea);
        }

        public IActionResult Save(AssembleiaViewModel assembleiaViewModel)
        {
            AssembleiaDao.Save(assembleiaViewModel.Assembleia);
            assembleiaViewModel.Assembleias = AssembleiaDao.List();

            return RedirectToAction("Index", new AssembleiaViewModel());
        }
    }
}