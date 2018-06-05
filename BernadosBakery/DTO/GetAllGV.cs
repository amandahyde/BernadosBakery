using BernadosBakery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BernadosBakery.DTO
{ 
    public class GetAllGV
{
    
        public List<Guest> guests = new List<Guest>();

        public List<Reservation> reservations = new List<Reservation>();

        public myReservations myReservation { get; set; }

    }
}
