using Garage_2._0.DataAccessLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Garage_2._0.Models
{
    public class ValidateRegNo : ValidationAttribute
    {
        private readonly RegisterContext db = new RegisterContext();

        public override bool IsValid(object value)
        {
            foreach (var item in db.ParkedVehicles.ToList()) {
                if(value is string) {
                    if ((string)value == item.RegNo)
                        return (false);
                }
            }
            return true;
        }
    }
}