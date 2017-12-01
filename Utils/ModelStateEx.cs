using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Utils {
    public static class ModelStateEx {
        public static string GetErrors(this ModelStateDictionary model ) {
            StringBuilder sb = new StringBuilder();
            foreach (var item in model.Values) {
                foreach (var item2 in item.Errors)
                    sb.AppendLine(item2.ErrorMessage);
            }
            return sb.ToString();
        }
    }
}
