using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Manage.Models
{

    public class Room
    {
        [Key]
        public int Id { get; set; }
        public List<int> Reservations { get; set; }
        [Display(Name = "Status")]
        public bool CurrentlyBooked { get; set; }
        public int CurrentCustomerId { get; set; }
        public List<int> Jobs { get; set; }
        [Display(Name = "Capacitate")]
        public int RoomSize { get; set; }

        [Display(Name = "Pret pe noapte")]
        public int PricePerNight { get; set; }

        public Room()
        {
            Reservations = new List<int>();
            CurrentCustomerId = -1;
            CurrentlyBooked = false;
            Jobs = new List<int>();
            RoomSize = 2;
            PricePerNight = 200;
        }
    }

    
}