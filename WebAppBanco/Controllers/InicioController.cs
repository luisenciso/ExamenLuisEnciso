using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppBanco.Controllers
{
    public class InicioController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {


            return View();
        }
    }


    [HttpPost]    
    [ValidateAntiForgeryToken]
    public ActionResult Login(Models.Usuario model)
    {
        string authId = Guid.NewGuid().ToString();
        Session["AuthID"] = authId;
        var cookie = new HttpCookie("AuthID");
        cookie.Value = authId;
        cookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookie);
        


    }
}
