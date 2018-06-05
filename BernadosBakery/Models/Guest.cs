using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BernadosBakery.Models
{
    public class Guest
    {

        [Key] 
        public int GuestId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

     



    }
}
