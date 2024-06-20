using BLL.DTO.PosDTO;
using BLL.Repositories.Pos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PosController : Controller
    {
        private readonly IPosRepository posRepository;
         
        public PosController(IPosRepository posRepository)
        {
            this.posRepository = posRepository;
        }
        
        // GET: Pos
        public ActionResult BrowsePos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePos() 
        {
            ViewBag.City = posRepository.GetAllCitites();
            ViewBag.ConType = posRepository.GetAllConnectionType();
            return View();
        }
        [HttpPost]  
        public ActionResult CreatePos(AddPosDTO model)
        {
            if (ModelState.IsValid)
            {
				posRepository.AddPos(model);
			}
			ViewBag.City = posRepository.GetAllCitites();
			ViewBag.ConType = posRepository.GetAllConnectionType();
			return View();
        }
    }
}