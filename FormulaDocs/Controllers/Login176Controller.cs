using FormulaDocs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Text;

namespace FormulaDocs.Controllers
{
    public class Login176Controller : Controller
    {
        FormulaDocsDBEntities db = new FormulaDocsDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            if(Session["Role"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }

        [HttpPost]
        public ActionResult Index(string username , string password)
        {
            if (ModelState.IsValid)
            {
                //var inputPassword = GetMD5(password);
                var data = db.MemberShip.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).ToList();

                if(data.Count() > 0)
                {
                    Session["Id"] = data.FirstOrDefault().Id.ToString();
                    Session["Name"] = data.FirstOrDefault().Name.ToString();
                    Session["Username"] = data.FirstOrDefault().Username.ToString();
                    Session["Role"] = data.FirstOrDefault().Role.ToString();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //Password Hash MD5
        public string GetMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(password);
            byte[] targetData = md5.ComputeHash(fromData);

            string byteToString = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byteToString += targetData[i].ToString("x2");
            }
            return byteToString;

        }
    }
}