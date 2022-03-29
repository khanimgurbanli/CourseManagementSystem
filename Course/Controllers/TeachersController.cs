using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class TeachersController : Controller
    {

        private readonly ApplicationDbContext db;
        public TeachersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        Teachers thr= new();


        public IActionResult ListOfTeachers()
        {
            return View(db.Teachers.ToList());
        }


        public IActionResult AddTeacher()
        {
            return View();
        }



        [HttpPost]
        public IActionResult AddTeacher(Teachers teacher)
        {


            if (!ModelState.IsValid)
            {
                return View("AddTeacher");
            }

            var getListTeachers = db.Teachers.ToList();

            var checkTeacher = getListTeachers
                .Any(t => t.FirstName == teacher.FirstName
                   && t.LastName == teacher.LastName
                    && t.FatherName == teacher.FatherName
                    && t.Birthdate == teacher.Birthdate
                    && t.Mail == teacher.Mail && t.Mobile == teacher.Mobile);

            if (checkTeacher)
            {
                ViewBag.checkResultMessage = "The teacher already exiest";
                return View("AddTeacher");
            }
            else
            {

                thr.Status = 1;
                thr.FirstName = teacher.FirstName;
                thr.LastName = teacher.LastName;
                thr.FatherName = teacher.FatherName;
                thr.Birthdate = teacher.Birthdate;
                thr.EnrollmentDate = DateTime.Today;
                thr.Mail = teacher.Mail;
                thr.Mobile = teacher.Mobile;

                db.Add(thr);
                db.SaveChanges();

                return RedirectToAction("ListOfTeachers");
            }

        }



        public IActionResult GetTeacher(int? id)
        {
            if (id != null)
            {
                var getTeacherById = db.Teachers.Where(c => c.Id == id).FirstOrDefault();

                if (getTeacherById == null)
                    return View();
                else
                    return View(getTeacherById);
            }

            return View();
        }



        [HttpPost]
        public IActionResult EditTeacher(Teachers teacher)
        {
            if (!ModelState.IsValid)
            {
                return View("GetTeacher", teacher);
            }

            var editTeacherById = db.Teachers.Where(c => c.Id == teacher.Id).FirstOrDefault();

            editTeacherById.FirstName = teacher.FirstName;
            editTeacherById.LastName = teacher.LastName;
            editTeacherById.FatherName = teacher.FatherName;
            editTeacherById.Birthdate = teacher.Birthdate;
            editTeacherById.EnrollmentDate = teacher.EnrollmentDate;
            editTeacherById.Mail = teacher.Mail;
            editTeacherById.Mobile = teacher.Mobile;

            db.Update(editTeacherById);
            db.SaveChanges();

            return RedirectToAction("ListOfTeachers");
        }


        public IActionResult ConfirmTeacher(int? id)
        {
            var checkStatus = db.Teachers.Where( t=> t.Id == id).FirstOrDefault();

            if (checkStatus.Status == 0)
            {
                thr.Status = 1;
                db.Update(thr);
                db.SaveChanges();
            }

            return RedirectToAction("ListOfTeachers");
        }


        public IActionResult DeleteTeacher(int? id)
        {
            //deactive-0
            //active-1
            //deleted-2

            var deleteTeacherById = db.Teachers.Where(t => t.Id == id).FirstOrDefault();

            deleteTeacherById.Status = 2;
            db.Update(deleteTeacherById);
            db.SaveChanges();

            return RedirectToAction("ListOfTeachers");
        }

        public IActionResult EnableTeacher(int? id)
        {

            var enableTeacherById = db.Teachers.Where(t => t.Id == id).FirstOrDefault();

            enableTeacherById.Status = 1;
            db.Update(enableTeacherById);
            db.SaveChanges();

            return RedirectToAction("ListOfTeachers");
        }
    }
}
