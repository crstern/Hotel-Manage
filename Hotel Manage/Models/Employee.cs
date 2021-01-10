using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Manage.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public float Salary { get; set; }

        public List<int> Jobs { get; set; }

    }
}