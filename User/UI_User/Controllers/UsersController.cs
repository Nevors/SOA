using Domain_User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_User.Infrastructure;

namespace UI_User.Controllers {
    public class UsersController : Controller {
        private EFContext db = new EFContext();
        // GET: Users
        public ActionResult Login(User user) {
            var tUser = db.Users.Where(u => u.Login.CompareTo(user.Login) == 0 && u.Password.CompareTo(user.Password) == 0)
                .FirstOrDefault();
            if (tUser != null) {
                db.Entry(tUser).Reference(u => u.Role).Load();
                return Json(tUser, JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = 401;
            return new ContentResult { Content = "Ошибка авторизации" };
        }
        public ActionResult Index() {
            return Json(db.Users.Select(user => new { Id = user.Id, Login = user.Login }));
        }
    }
}