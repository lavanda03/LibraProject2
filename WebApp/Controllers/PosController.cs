using BBL.DTO.UserDTO.UserValidation;
using BLL.DTO.PosDTO;
using BLL.Repositories.Pos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    [Authorize]
    public class PosController : Controller
    {
        private readonly IPosRepository posRepository;
       
         
        public PosController(IPosRepository posRepository)
        { 
             this.posRepository = posRepository;
            
        }

        // GET: Pos
        [HttpGet]
        public ActionResult BrowsePos()
        {
            return View();
        }


        [HttpGet]
        public JsonResult QueryPos()
        {
            var criteria = Request.GetPaginatingCriteria();

            var pos = posRepository.QueryPos(criteria);

            var jsonData = new
            {
                draw = Request.QueryString["draw"],
                recordTotal = pos.Total,
                recordsFiltered = pos.TotalFiltered,
                data = pos.PossDTO
             
            };
            
            return Json(jsonData,JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult CreatePos() 
        {
            
            ViewBag.City = posRepository.GetAllCitites();
            ViewBag.ConType = posRepository.GetAllConnectionType();
          //  ViewBag.WeekDays = posRepository.
            return View();
        }

        [HttpPost]  
        public ActionResult CreatePos(AddPOSDTO posModel)
        {
            if (ModelState.IsValid)
            {
                posRepository.AddPos(posModel);
				return RedirectToAction("BrowsePos");
			}
            
		
			ViewBag.City = posRepository.GetAllCitites();
			ViewBag.ConType = posRepository.GetAllConnectionType();

            return View();
        }

        [HttpGet]
        public ActionResult EditPos(int id)
        {
           var pos = posRepository.GetPosById(id);

			ViewBag.City = posRepository.GetAllCitites();
			ViewBag.ConType = posRepository.GetAllConnectionType();

			return View(pos);
        }

        [HttpPost]
        public ActionResult EditPos(UpdatePosDTO updatePos)
        {
            if (ModelState.IsValid)
            {
                posRepository.UpdatePos(updatePos);
                return RedirectToAction("EditPos", new { id =updatePos.Id });

            }
			return PartialView("EditPosPartialView",updatePos);  
        }

        [HttpGet]
        public ActionResult EditPosPartialView()
        {
			var pos = posRepository.GetPosById(1);

			ViewBag.City = posRepository.GetAllCitites();
			ViewBag.ConType = posRepository.GetAllConnectionType();

			return PartialView("EditPosPartialView",pos);
        }
    }
}