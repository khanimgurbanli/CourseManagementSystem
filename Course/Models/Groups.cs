using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Models
{
    public class Groups
    {
        [Key]
        public int ID { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "Group name is required")]
        [StringLength(50, ErrorMessage = "You can enter a maximum of 50, minimum of 3 character elements.", MinimumLength = 3)]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Begin date is required")]
        public DateTime BeginDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        public List<Students> Students{ get; set; }

        public int CourseId { get; set; }
        public Courses Course { get; set; }

        public int TeacherId { get; set; }
        public Teachers Teacher { get; set; }

    }
}
