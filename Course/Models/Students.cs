using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Models
{
    public class Students 
    {
        [Key]
        public int ID { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid FirstName ")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid LastName ")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "FatherName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid FatherName ")]
        public string FatherName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime EnrollmentDate { get; set; }

        [Required(ErrorMessage = "Mail is required")]
        [RegularExpression(@" ^[a - zA - Z0 - 9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Invalid Mail number")]  
        public string Mail { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [RegularExpression(@"^(?=.*[0-9])[- .()0-9]+$", ErrorMessage = "Invalid Mobile number")]
        public string Mobile { get; set; }
        public List<Groups> Groups { get; set; }
    }
}
