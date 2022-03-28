using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext db;
        public StudentsController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IActionResult ListOfStuddents()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Students student)
        {
            return View();
        }

        public IActionResult GetStudent()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EditStudent(Students student)
        {
            return View();
        }
    }
}
