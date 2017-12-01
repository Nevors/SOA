using Domain_User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Utils {
    public class UserModelBinder : IModelBinder {
        const string userPrefix = "user";
        const string loginPrefix = "user.login";
        const string passwordPrefix = "user.password";
        const string login = "login";
        const string password = "password";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            User user = new User();
            var vp = bindingContext.ValueProvider;
            if (vp.ContainsPrefix(userPrefix)) {
                if (vp.ContainsPrefix(loginPrefix)) {
                    user.Login = (string)vp.GetValue(loginPrefix).ConvertTo(typeof(string));
                }
                if (vp.ContainsPrefix(passwordPrefix)) {
                    user.Password = (string)vp.GetValue(passwordPrefix).ConvertTo(typeof(string));
                }
            }else {
                if (vp.ContainsPrefix(login)) {
                    user.Login = (string)vp.GetValue(login).ConvertTo(typeof(string));
                }
                if (vp.ContainsPrefix(password) ){
                    user.Password = (string)vp.GetValue(password).ConvertTo(typeof(string));
                }
            }
            controllerContext.Controller.ViewBag.UserBinder = user;
            return user;
        }
    }
}
