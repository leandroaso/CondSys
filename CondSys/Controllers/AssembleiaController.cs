﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondSys.DAO;
using CondSys.Models.Entidades;
using CondSys.Models.ViewModel;
using CondSys.Negocio;
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
            if (UsuarioLogado.Usuario == null)
                return RedirectToAction("index", "Login");

            var assemblea = new AssembleiaViewModel();
            assemblea.Assembleias = AssembleiaDao.List();
            return View(assemblea);
        }

        public IActionResult Save(AssembleiaViewModel assembleiaViewModel)
        {
            try
            {
                var assembleia = assembleiaViewModel.Assembleia;
                new AssembleiaNegocio(AssembleiaDao).SalvarAssembleia(assembleia);
                assembleiaViewModel.Assembleias = AssembleiaDao.List();

                return Json(new {Status = "OK", Message = "Cadastrado com Sucesso!" });
            }
            catch(Exception ex)
            {
                return Json(new {Status = "NOK", Message = ex.Message.ToString() });
            }
        }

        public IActionResult Delete(int id)
        {
            var result = AssembleiaDao.Delete(id);
            if (result)
                return Ok("success");

            return Ok();
        }


    }
}