using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
