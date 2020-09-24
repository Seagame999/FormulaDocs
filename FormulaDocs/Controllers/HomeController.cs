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
    public class HomeController : Controller
    {
        FormulaDocsDBEntities db = new FormulaDocsDBEntities();

        public ActionResult Index()
        {
            var publicRelationResult = db.PublicRelation.Where(x => x.DataIsActive == true).ToList().LastOrDefault();

            return View(publicRelationResult);
        }
    }
}