using BLL.DTO.PosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PosController : Controller
    {
        // GET: Pos
        public ActionResult BrowsePos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePos() 
        {
            return View();
        }
        [HttpPost]  
        public ActionResult CreateePos(AddPosDTO model)
        {
            return View(model);
        }
    }
}