using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class CourseController : Controller
    {

        private readonly ApplicationDbContext db;
        public CourseController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult ListOfCourse()
        {
            return View(db.Courses.ToList());
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Courses course)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCourse");
            }


            Courses crs = new();
            crs.Status =1;
            crs.Name = course.Name;
            crs.Price = course.Price;
            crs.Date = course.Date;

            db.Add(crs);
            db.SaveChanges();

            return RedirectToAction("ListOfCourse");
        }

        public IActionResult GetCourse(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var course = db.Courses.Where(c => c.ID == id).FirstOrDefault();

                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
        }

        [HttpPost]
        public IActionResult EditCourse(Courses course)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCourse");
            }

            var editCourseById = db.Courses.Where(c => c.ID == course.ID).FirstOrDefault();

            editCourseById.Name = course.Name;
            editCourseById.Price = course.Price;
            editCourseById.Date = course.Date;

            db.Update(editCourseById);
            db.SaveChanges();

            return RedirectToAction("ListOfCourse");
        }

        public IActionResult DeleteCourse(int id)
        {
            var deleteCourseById = db.Courses.Find(id);

            deleteCourseById.Status = 0;
            db.Update(deleteCourseById);
            db.SaveChanges();

            return RedirectToAction("ListOfCourse");
        }
    }
}
