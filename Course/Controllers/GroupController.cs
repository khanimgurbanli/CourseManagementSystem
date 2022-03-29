using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext db;
        public GroupController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IActionResult ListOfGroups()
        {
            var result = db.Groups
            .Include(m => m.Teacher)
            .Include(m => m.Course)
            .ToList();

            return View(result);
        }






        public IActionResult CreateGroup()
        {
            List<SelectListItem> DropDownTeacherList = (from x in db?.Teachers?.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.FirstName,
                                                            Value = x.Id.ToString()
                                                        }).ToList();
            ViewBag.TeacherList = DropDownTeacherList;


            List<SelectListItem> DropDownCourseList = (from x in db?.Courses?.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            ViewBag.CourseList = DropDownCourseList;
            return View();
        }






        [HttpPost]
        public IActionResult CreateGroup(Groups group)
        {

            List<SelectListItem> DropDownTeacherList = (from x in db?.Teachers?.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.FirstName,
                                                            Value = x.Id.ToString()
                                                        }).ToList();
            ViewBag.TeacherList = DropDownTeacherList;


            List<SelectListItem> DropDownCourseList = (from x in db?.Courses?.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            ViewBag.CourseList = DropDownCourseList;

            if (!ModelState.IsValid)
            {
                return View("CreateGroup");
            }


            var getListGroups = db.Groups.ToList();
            var checkGroup = getListGroups
                .Any(g => g.Name == group.Name
                   && g.BeginDate == group.BeginDate
                    && g.EndDate == group.EndDate && g.Teacher == group.Teacher && g.Course == group.Course);

            if (checkGroup)
            {
                ViewBag.checkResultMessage = "The group already exiest";
                return View("CreateGroup");
            }
            else
            {

                var tchr = db.Teachers.Where(x => x.Id == group.TeacherId).FirstOrDefault();
                var crs = db.Courses.Where(x => x.ID == group.CourseId).FirstOrDefault();

                Groups grp = new();
                grp.Name = group.Name;
                grp.Status = 1;
                grp.BeginDate = group.BeginDate;
                grp.EndDate = group.EndDate;
                grp.Teacher = tchr;
                grp.Course = crs;

                db.Add(grp);
                db.SaveChanges();

                return RedirectToAction("ListOfGroups");
            }

        }




        public IActionResult GetGroup(int? id)
        {
            List<SelectListItem> DropDownTeacherList = (from x in db?.Teachers?.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.FirstName,
                                                            Value = x.Id.ToString()
                                                        }).ToList();
            ViewBag.TeacherList = DropDownTeacherList;

            List<SelectListItem> DropDownCourseList = (from x in db?.Courses?.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            ViewBag.CourseList = DropDownCourseList;

            if (id != null)
            {
                var getGroupById = db.Groups.Where(c => c.ID == id).FirstOrDefault();

                if (getGroupById == null)
                    return View();
                else
                    return View(getGroupById);
            }

            return View();
        }

        [HttpPost]
        public IActionResult EditGroup(Groups group)
        {

            List<SelectListItem> DropDownTeacherList = (from x in db?.Teachers?.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.FirstName,
                                                            Value = x.Id.ToString()
                                                        }).ToList();
            ViewBag.TeacherList = DropDownTeacherList;

            List<SelectListItem> DropDownCourseList = (from x in db?.Courses?.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            ViewBag.CourseList = DropDownCourseList;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetGroup", group);
            }


            var editGroupById = db.Groups.Where(c => c.ID == group.ID).FirstOrDefault();

            var tchr = db.Teachers.Where(x => x.Id == group.TeacherId).FirstOrDefault();
            var crs = db.Courses.Where(x => x.ID == group.CourseId).FirstOrDefault();

            editGroupById.Name = group.Name;
            editGroupById.BeginDate = group.BeginDate;
            editGroupById.EndDate = group.EndDate;
            editGroupById.Course = crs;
            editGroupById.Teacher = tchr;

            db.Update(editGroupById);
            db.SaveChanges();

            return RedirectToAction("ListOfGroups");

        }

        public IActionResult ActiveeGroup(int? id)
        {
            var activeGroupById = db.Groups.Where(g => g.ID == id).FirstOrDefault();


            activeGroupById.Status = 1;
            activeGroupById.EndDate = DateTime.Now;
            db.Update(activeGroupById);
            db.SaveChanges();

            return RedirectToAction("ListOfGroups");
        }

        public IActionResult DeactiveGroup(int? id)
        {
            var deactiveGroupById = db.Groups.Where(g => g.ID == id).FirstOrDefault();

            deactiveGroupById.Status = 0;
            deactiveGroupById.EndDate = DateTime.Now;
            db.Update(deactiveGroupById);
            db.SaveChanges();

            return RedirectToAction("ListOfGroups");
        }


        public IActionResult DeleteGroup(int? id)
        {
            var deleteGroupById = db.Groups.Where(g => g.ID == id).FirstOrDefault();

            deleteGroupById.Status = 2;
            deleteGroupById.EndDate = DateTime.Now;
            db.Update(deleteGroupById);
            db.SaveChanges();

            return RedirectToAction("ListOfGroups");
        }
    }
}
