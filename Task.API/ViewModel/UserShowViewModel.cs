using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.API.Utility;
namespace Task.UI.ViewModel
{
    public class UserShowViewModel
    {
        public int Id{ get; set; }

        public string FirstName { get; set; }
       
        public string MiddleName { get; set; }
      
        public string LastName { get; set; }

        public string Email { get; set; }
       
        public DateTime BirthDate { get; set; }
        
        public string MobileNumber { get; set; }
      
        public string Governrate { get; set; }
       
        public string  City { get; set; }
        
        public string Street { get; set; }
       
        public int BulDingNumber { get; set; }
       
        public int FlatNumber { get; set; }
    }
}
