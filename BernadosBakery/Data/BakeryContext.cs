using BernadosBakery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BernadosBakery.Data
{
    public class BakeryContext : DbContext
    {

        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
        {
            
        }

        public BakeryContext()
        {

        }
        public DbSet<Pie> Pie { get; set; }

        public DbSet<Cake> Cake { get; set; }

        public DbSet<Drink> Drink { get; set; }

        public DbSet<Sandwich> Sandwich { get; set; }

      

        public DbSet<BernadosBakery.Models.Guest> Guest { get; set; }

      

        public DbSet<BernadosBakery.Models.Reservation> Reservation { get; set; }

       

    }
}
