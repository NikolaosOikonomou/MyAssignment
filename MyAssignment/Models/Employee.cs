using MyAssignment.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAssignment.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DisplayName("Firstname")]
        [Required(ErrorMessage = "Firstname Is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ("Only Letters Allowed"))]
        [MinLength(2, ErrorMessage = "Above 3 letters")]
        [MaxLength(20, ErrorMessage = "Below 20 letters")]
        public string FirstName { get; set; }


        [DisplayName("Lastname")]
        [Required(ErrorMessage = "Lastname Is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ("Only Letters Allowed"))]
        [MinLength(2, ErrorMessage = "Above 3 letters")]
        [MaxLength(20, ErrorMessage = "Below 20 letters")]
        public string LastName { get; set; }

        [Range(18, 65, ErrorMessage = "Age must be between 18 - 65")]
        public int? Age { get; set; }

        public int? Salary { get; set; }

        public Country? Country { get; set; }

        //Foreign Key
        public int? ManagerId { get; set; }

        //Navigation Property
        public Manager Manager { get; set; }


    }
}