using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BernadosBakery.Data;
using BernadosBakery.Models;

namespace BernadosBakery.Controllers
{
    public class BigViewModelsController : Controller
    {
        private readonly BakeryContext _context;

        public BigViewModelsController(BakeryContext context)
        {
            _context = context;
        }

        // GET: BigViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pie.ToListAsync());

        }

        // GET: BigViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pie = await _context.Pie
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Pie == null)
            {
                return NotFound();
            }

            return View(Pie);
        }

      
    }
}
