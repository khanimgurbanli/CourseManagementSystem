using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
          //Admin qeydiyyatdan keçir. Hesab Təsdiqi rəhbərin Mailinə gələn təsdiq linki ilə gerçəkəşir
          //Qalan işlər=> 
          // 1-Lislərə filter  əlavə etmək
          // 2-Gogle chart istifadə etmək
          // 3- Kurs reklam posterləri və müəllim, tələbə profil şəkli əlavə etmək
          // 4-Student və Teacher cədvəllərinə kurs və grup əlavə etmək
          // 5-List datanı pdf olaraq yükləmək
            return View();
        }
    }
}
