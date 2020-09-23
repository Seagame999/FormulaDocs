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
    public class MathematicsController : Controller
    {
        FormulaDocsDBEntities db = new FormulaDocsDBEntities();

        // GET: Mathematics
        public ActionResult Index()
        {
            var mathTopic = new List<string>() { "พื้นที่","ปริมาตร","ฟังก์ชัน" };           
            ViewBag.mathTopicView = mathTopic;


            return View();
        }

        public ActionResult AddFormulas()
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
        public ActionResult AddFormulas(Mathematics mathematics)
        {
            if (ModelState.IsValid)
            {
                if (mathematics.image1http != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mathematics.image1http.FileName);
                    string extension = Path.GetExtension(mathematics.image1http.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("ddMMyy_HHmmss") + extension;
                    mathematics.Image1 = "/DataImage/MathematicsImg/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/DataImage/MathematicsImg/"), fileName);
                    mathematics.image1http.SaveAs(fileName);
                }

                if (mathematics.image2http != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mathematics.image2http.FileName);
                    string extension = Path.GetExtension(mathematics.image2http.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("ddMMyy_HHmmss") + extension;
                    mathematics.Image2 = "/DataImage/MathematicsImg/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/DataImage/MathematicsImg/"), fileName);
                    mathematics.image2http.SaveAs(fileName);
                }

                if (mathematics.image3http != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mathematics.image3http.FileName);
                    string extension = Path.GetExtension(mathematics.image3http.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("ddMMyy_HHmmss") + extension;
                    mathematics.Image3 = "/DataImage/MathematicsImg/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/DataImage/MathematicsImg/"), fileName);
                    mathematics.image3http.SaveAs(fileName);
                }

                if (mathematics.image4http != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mathematics.image4http.FileName);
                    string extension = Path.GetExtension(mathematics.image4http.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("ddMMyy_HHmmss") + extension;
                    mathematics.Image4 = "/DataImage/MathematicsImg/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/DataImage/MathematicsImg/"), fileName);
                    mathematics.image4http.SaveAs(fileName);
                }

                if (mathematics.image5http != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mathematics.image5http.FileName);
                    string extension = Path.GetExtension(mathematics.image5http.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("ddMMyy_HHmmss") + extension;
                    mathematics.Image5 = "/DataImage/MathematicsImg/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/DataImage/MathematicsImg/"), fileName);
                    mathematics.image5http.SaveAs(fileName);
                }

                mathematics.Date = DateTime.Today;
                mathematics.DataIsActive = true;

                db.Mathematics.Add(mathematics);
                db.SaveChanges();
                ModelState.Clear();

                return RedirectToAction("Index", "Home");
            }

            return View(mathematics);
        }

        public ActionResult Areas()
        {
            var areasResult = db.Mathematics.Where(x => x.Category.Equals("พื้นที่")).ToList();

            return View(areasResult);
        }

        public ActionResult Formulas(int id)
        {
            Mathematics mathematics = db.Mathematics.Find(id);

            if(mathematics == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(mathematics);

        }
    }
}