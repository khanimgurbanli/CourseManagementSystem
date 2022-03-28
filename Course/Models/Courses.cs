using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Models
{
    public class Courses
    {
        [Key]
        public int ID { get; set; }
        public int Status { get; set; }
        
        [Required(ErrorMessage = "Course name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid course name ")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50 character elements.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime Date { get; set; }

        public List<Groups> Groups { get; set; }


    }
}
