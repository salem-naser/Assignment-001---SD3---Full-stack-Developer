using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.UI.Utility;

namespace Task.UI.ViewModel
{
    public class UserViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This Field Required")]
        [MaxLength(20,ErrorMessage = "Max Length 20 Car")]
        [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_ ]*$", ErrorMessage = "Use Characters only")]
       
        public string FirstName { get; set; }
        [Display(Name = "Middle  Name")]
        [MaxLength(40,ErrorMessage = "Max Length 40")]
        [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_ ]*$", ErrorMessage = "Use Characters only")]
        [Required]
        public string MiddleName{ get; set; }
         [Display(Name = "Last Name")]
         [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_ ]*$", ErrorMessage = "Use Characters only")]
        [MaxLength(20,ErrorMessage = "Use Characters only")]
         [Required]
        public string LastName { get; set; }
      
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "Enter Valid Email ")]
        public string Email { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
      
        [Required]
        [MinimumAge(20, ErrorMessage="Minimum Age 20 years")]
        public DateTime BirthDate { get; set; }
        [Phone]
        [RegularExpression(@"(\+0[2])[0-9]{11}", ErrorMessage = "Enter A Valid  Number ")]
        [Required]
        public string MobileNumber { get; set; }
        [Display(Name = "Govenrate")]
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Select A city From  List")]
        public int Governrate { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Select A city From  List")]
        public int City { get; set; }
        [Required(ErrorMessage ="This Field Required")]
        [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_ ]*$", ErrorMessage = "Use Characters only")]
        [MaxLength(200,ErrorMessage = "Max Length 200 car ")]
        public string Street{ get; set; }
        [Required(ErrorMessage = "This Fiels Is Requires")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter a Valid Number")]
        public int BulDingNumber { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter a Valid Number")]
        public int FlatNumber { get; set; }

    }
}
