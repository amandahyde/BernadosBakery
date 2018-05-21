using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BernadosBakery.Models
{
    public class Cake
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }


        public bool IsCakeOfWeek { get; set; }
    }
}
