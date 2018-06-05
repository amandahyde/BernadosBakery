using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BernadosBakery.Data;
using BernadosBakery.Models;
using static BernadosBakery.Models.GetAll;

namespace BernadosBakery.Controllers
{
    public class MenuItemsController : Controller
    {

        private readonly BakeryContext _context;

        public MenuItemsController(BakeryContext context)
        {
            _context = context;
        }


        public ActionResult IndexViewModel()
        {
            ViewBag.Message = "Welcome to my demo!";
        //    ViewModel mymodel = new ViewModel();
         

            var dbpies = _context.Pie.ToList();
            GetAll mygetall = new GetAll();

            mygetall.pies.AddRange(dbpies);

            return View(dbpies);
        }

       
          
    }
}
