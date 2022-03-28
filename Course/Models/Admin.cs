using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid FirstName ")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50 character elements.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid LastName ")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50 character elements.", MinimumLength = 3)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "FatherName is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid FatherName ")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50 character elements.", MinimumLength = 3)]
        public string FatherName { get; set; }


        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime Birtdate { get; set; }


        [Required(ErrorMessage = "Mail is required")]
        [RegularExpression(@" ^[a - zA - Z0 - 9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Invalid Mail number")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
