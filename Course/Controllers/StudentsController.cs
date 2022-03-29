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
        Students st = new();

        public IActionResult ListOfStudents()
        {
            return View(db.Students.ToList());
        }



        public IActionResult AddStudent()
        {

            return View();
        }



        [HttpPost]
        public IActionResult AddStudent(Students student)
        {
           

            if (!ModelState.IsValid)
            {
                return View("AddStudent");
            }

            var getListStudentts = db.Students.ToList();

            var checkStudent = getListStudentts
                .Any(s => s.FirstName== student.FirstName
                   && s.LastName == student.LastName
                    && s.FatherName == student.FatherName 
                    && s.Birthdate == student.Birthdate
                    && s.Mail == student.Mail && s.Mobile==student.Mobile);

            if (checkStudent)
            {
                ViewBag.checkResultMessage = "The student already exiest";
                return View("AddStudent");
            }
            else
            {

               
                st.Status = 1;
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.FatherName = student.FatherName;
                st.Birthdate = student.Birthdate;
                st.EnrollmentDate = DateTime.Today;
                st.Mail = student.Mail;
                st.Mobile = student.Mobile;

                db.Add(st);
                db.SaveChanges();

                return RedirectToAction("ListOfStudents");
            }

        }



        public IActionResult GetStudent(int? id)
        {
            if (id != null)
            {
                var getStudentById = db.Students.Where(s => s.ID == id).FirstOrDefault();

                if (getStudentById == null)
                    return View();
                else
                    return View(getStudentById);
            }

            return View();
        }



        [HttpPost]
        public IActionResult EditStudent(Students student)
        {
            if (!ModelState.IsValid)
            {
                return View("GetStudent", student);
            }

            var editStudentById = db.Students.Where(s => s.ID == student.ID).FirstOrDefault();

            editStudentById.FirstName = student.FirstName;
            editStudentById.LastName = student.LastName;
            editStudentById.FatherName = student.FatherName;
            editStudentById.Birthdate = student.Birthdate;
            editStudentById.EnrollmentDate = student.EnrollmentDate;
            editStudentById.Mail = student.Mail;
            editStudentById.Mobile = student.Mobile;

            db.Update(editStudentById);
            db.SaveChanges();

            return RedirectToAction("ListOfStudents");
        }


        public IActionResult ConfirmStudent(int? id)
        {
            var checkStatus = db.Students.Where(s => s.ID == id).FirstOrDefault();

            if (checkStatus.Status == 0)
            {
                st.Status = 1;
                db.Update(st);
                db.SaveChanges();
            }
          
            return RedirectToAction("ListOfStudents");
        }
        

        public IActionResult DeleteStudent(int? id)
        {
            //deactive-0
            //active-1
            //deleted-2

            var deleteStudentyId = db.Students.Where(s => s.ID == id).FirstOrDefault();

            deleteStudentyId.Status = 2;
            db.Update(deleteStudentyId);
            db.SaveChanges();

            return RedirectToAction("ListOfStudents");
        }

        public IActionResult EnableStudent(int? id)
        {

            var enableStudentyId = db.Students.Where(s=> s.ID == id).FirstOrDefault();

            enableStudentyId.Status = 1;
            db.Update(enableStudentyId);
            db.SaveChanges();

            return RedirectToAction("ListOfStudents");
        }
    }
}
