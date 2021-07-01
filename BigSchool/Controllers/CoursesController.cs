using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private BigSchoolContext db = new BigSchoolContext();
        private Course obj = new Course();
        public ActionResult Create()
        {
            obj.ListCategory = db.Categories.ToList();
            return View(obj);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course obj)
        {
            //Không xet LectureId vì bằng user đăng nhập
            ModelState.Remove("LectureId");
            if (!ModelState.IsValid)
            {
                obj.ListCategory = db.Categories.ToList();
                return View("Create", obj);
            }
            //Lấy login user ID
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            obj.LectureId = user.Id;

            //Add vào CSDL
            db.Courses.Add(obj);
            db.SaveChanges();

            //Trở về home, Action Index
            return RedirectToAction("Index", "Home");
        }
    }
}