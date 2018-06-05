using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BernadosBakery.Models;
using static BernadosBakery.Models.GetAll;
using BernadosBakery.Data;
using Microsoft.AspNetCore.Authorization;

namespace BernadosBakery.Controllers
{
    public class HomeController : Controller
    {

        private readonly BakeryContext _context;

        public HomeController (BakeryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           

            var dbcakes = _context.Cake.ToList();
            var dbpies = _context.Pie.ToList();
            var dbsandwiches = _context.Sandwich.ToList();
            var dbdrinks = _context.Drink.ToList();


            GetAll mygetall = new GetAll();

            mygetall.pies.AddRange(dbpies);
            mygetall.cakes.AddRange(dbcakes);
            mygetall.drinks.AddRange(dbdrinks);
            mygetall.sandwichs.AddRange(dbsandwiches);


            return View(mygetall);
        }


        [Authorize]
        public IActionResult About()

          
        {
            ViewData["Message"] = "Your application description page.";

            var dbcakes = _context.Cake.ToList();
            var dbpies = _context.Pie.ToList();
            var dbsandwiches = _context.Sandwich.ToList();
            var dbdrinks = _context.Drink.ToList();


            GetAll mygetall = new GetAll();

            mygetall.pies.AddRange(dbpies);
            mygetall.cakes.AddRange(dbcakes);
            mygetall.drinks.AddRange(dbdrinks);
            mygetall.sandwichs.AddRange(dbsandwiches);


            return View(mygetall);
        }

        [Authorize]
        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
