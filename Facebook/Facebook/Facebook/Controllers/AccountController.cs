using Facebook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facebook.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult GetLoginView()
        {
            return View("Login");
        }

        public ActionResult GetRegisterView()
        {
            return View("Register");
        }
        [HttpGet]
        public ActionResult Register(User obj, HttpPostedFileBase img)
        {
            string path = Uploadimage(img);
            if (ModelState.IsValid|| !path.Equals("-1"))
            {
                Models.FacebookDbEntities db = new Models.FacebookDbEntities();
                db.Users.Add(obj);
                obj.Image = path;
                db.SaveChanges();
            }
            return View(obj);
        }
       /* [HttpPost]*/
       /* public ActionResult Register(User obj, HttpPostedFileBase img)
        {
            Models.FacebookDbEntities db = new Models.FacebookDbEntities();
            string path = Uploadimage(img);
            if (path.Equals("-1"))
            {

            }
            else
            {
                obj.Image = path;
                db.SaveChanges();
                ViewBag.msg = "img sucsess";
            }
            return View(obj);
        }*/
        public string Uploadimage(HttpPostedFileBase file)

        {

            Random r = new Random();

            string path = "-1";

            int random = r.Next();

            if (file != null && file.ContentLength > 0)

            {

                string extension = Path.GetExtension(file.FileName);

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))

                {

                    try

                    {



                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));

                        file.SaveAs(path);

                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);



                        //    ViewBag.Message = "File uploaded successfully";

                    }

                    catch (Exception ex)

                    {

                        path = "-1";

                    }

                }

                else

                {

                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");

                }

            }



            else

            {

                Response.Write("<script>alert('Please select a file'); </script>");

                path = "-1";

            }







            return path;

        }
        /*[HttpPost]
        public ActionResult RegisterC( Models.User usermodel)
        {
            using (FacebookDbEntities user = new FacebookDbEntities())
            {
                user.Users.Add(usermodel);
                user.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccsessMessage = "Registration Succsessful";
            return View("AddOrEdit", new FacebookDbEntities());
        }
        public ActionResult Index(User obj)

        {
            if (ModelState.IsValid)
            {
                Models.FacebookDbEntities db = new Models.FacebookDbEntities();
                db.Users.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }*/



    }
}