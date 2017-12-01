using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Domain_User.Entity;

namespace Utils {
    public class MyAuthAttribute : ActionFilterAttribute {
        const string auth = "http://localhost:20000/Login/";

        public string Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            User user;
            user = filterContext.Controller.ViewBag.UserBinder as User;
            if (user == null) {
                var r = new UserModelBinder();
                var model = new ModelBindingContext();
                model.ValueProvider = filterContext.Controller.ValueProvider;
                user = (User)r.BindModel(filterContext, model);

            }

            WebClient web = new WebClient();
            var str = JsonConvert.SerializeObject(user);
            web.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=utf-8");
            string result = null;
            try {
                result = web.UploadString(auth, str);
                User tUser = JsonConvert.DeserializeObject<User>(result);
                if (Roles == null || Roles.Equals("All") || Roles.Split(',').Where(p => tUser.Role.Name.CompareTo(p) == 0).Any()) {
                    user.Id = tUser.Id;
                    user.Role = tUser.Role;
                    user.RoleId = tUser.RoleId;
                    return;
                }
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.Result = new ContentResult { Content = "Недостаточно прав" };
                return;
            } catch (WebException e) {
                if (e.Status == WebExceptionStatus.ConnectFailure) {
                    filterContext.HttpContext.Response.StatusCode = 404;
                    filterContext.Result = new ContentResult { Content = "Auth server is not available" };
                    return;
                }
            }
            filterContext.HttpContext.Response.StatusCode = 401;
            filterContext.Result = new ContentResult { Content = "Ошибка авторизации" };
        }
    }
}
