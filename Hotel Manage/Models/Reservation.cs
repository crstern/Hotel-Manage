using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Manage.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public Tuple<DateTime, DateTime> BookingDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer{get; set;}

    }
}