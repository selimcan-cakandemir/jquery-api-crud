using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _100_WebApiCrud.Models.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Ad boş geçilemez!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}