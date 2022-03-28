
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Models
{
    public class Teachers 
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50, minimum of 3 character elements.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50, minimum of 3 character elements.", MinimumLength = 3)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "FatherName is required")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50, minimum of 3 character elements.", MinimumLength = 3)]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime Birthdate { get; set; }


        [Required(ErrorMessage = "Mail is required")]
        [RegularExpression(@" ^[a - zA - Z0 - 9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Invalid Mail number")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [RegularExpression(@"^(?=.*[0-9])[- .()0-9]+$", ErrorMessage = "Invalid Mobile number")]
        public string Mobile { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public List<Groups> Group { get; set; }
    }
}
