using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BernadosBakery.Models
{
    public class Reservation
    {

        public int ID { get; set; }

       public int GuestId { get; set; }

       public DateTime DateTime { get; set; }

        public int NumGuests { get; set; }

        public string SeatingType { get; set; }

        
       
    }
}
