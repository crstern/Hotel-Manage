using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Manage.Models.MyValidation
{
    public class MaxNumberValidation: ValidationAttribute
    {
        public int MaxNum { get; set; }

        public MaxNumberValidation(int param)
        {
            MaxNum = param;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var room = (Room)validationContext.ObjectInstance;
            int size = room.RoomSize;
            bool cond = true;
            if (size > MaxNum)
                cond = false;
            return cond ? ValidationResult.Success : new ValidationResult("The capacity of the room can not be more than 4");
        }
    }

    public class MinNumberValidation : ValidationAttribute
    {
        public int MinNum { get; set; }

        public MinNumberValidation(int param)
        {
            MinNum = param;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var room = (Room)validationContext.ObjectInstance;
            int price = room.PricePerNight;
            bool cond = true;
            if (price < MinNum)
                cond = false;
            return cond ? ValidationResult.Success : new ValidationResult("The price can not be negative!");
        }
    }
}