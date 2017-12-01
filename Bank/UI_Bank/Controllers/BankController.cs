using Domain_Bank.Entity;
using Domain_User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI_Bank.Infrastructure;
using Utils;

namespace UI_Bank.Controllers
{
    public class BankController : Controller {
        EFContext db = new EFContext();
        // GET: Accounts
        public ActionResult Index() {
            return Json(new { name = "Ряба", value = "Петуч" }, JsonRequestBehavior.AllowGet);
        }
        [MyAuth(Roles = "User,Admin")]
        [HttpPost]
        public ActionResult Payment(User user, Transaction data) {
            Account outAccount = db.Accounts.Where(a => a.LoginId == user.Id && a.Id == data.AccountOutId).FirstOrDefault();
            if (outAccount == null) {
                Response.StatusCode = 400;
                return new ContentResult {ContentEncoding = Encoding.UTF8, Content = "У пользователя нет такого счета" };
            }
            Account inAccount = db.Accounts.Where(a => a.Id == data.AccountInId).FirstOrDefault();
            if(inAccount == null) {
                Response.StatusCode = 400;
                return new ContentResult { ContentEncoding = Encoding.UTF8, Content = "Счета назначения не существует" };
            }
            if (outAccount.Balance - data.Count < 0) {
                Response.StatusCode = 400;
                return new ContentResult { ContentEncoding = Encoding.UTF8, Content = "Недостаточно средств" };
            }
            outAccount.Balance -= data.Count;
            inAccount.Balance += data.Count;

            data.Date = DateTime.Now;
            db.Transaction.Add(data);
            db.SaveChanges();
            return new EmptyResult();
        }

        [MyAuth(Roles = "All")]
        public ActionResult GetAccounts(User user) {
            return Json(db.Accounts.Where(a => a.LoginId == user.Id),JsonRequestBehavior.AllowGet);
        }
    }
}