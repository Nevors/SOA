using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Utils {
    public class CheckDataAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            string str = null;
            StringBuilder sb = new StringBuilder();
            var s = filterContext.HttpContext.Request.InputStream;
            if (s.CanRead) {
                int b = -1;
                while ((b = s.ReadByte()) != -1) {
                    sb.Append((char)b);
                }
                str = sb.ToString();
            }
        }
    }
}
