using FormulaDocs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Validation;

namespace FormulaDocs.Controllers
{
    public class PublicRelationController : Controller
    {
        FormulaDocsDBEntities db = new FormulaDocsDBEntities();

        // GET: PublicRelation
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult CreateNews()
        {
            if (Session["Role"] != null && Session["Role"].Equals("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateNews(PublicRelation publicRelation)
        {
            if (ModelState.IsValid)
            {
                publicRelation.Creator = Session["Name"].ToString();
                publicRelation.Date = DateTime.Today;
                publicRelation.DataIsActive = true;

                db.PublicRelation.Add(publicRelation);
                db.SaveChanges();
                ModelState.Clear();

                return RedirectToAction("Index","Home");
            }

            return View(publicRelation);
        }
    }
}