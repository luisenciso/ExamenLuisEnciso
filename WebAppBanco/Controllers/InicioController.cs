using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppBanco.Controllers
{
    public class InicioController : Controller
    {


        string url = "http://localhost:55033/";
        // GET: /<controller>/
        public IActionResult Index()
        {


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Models.Usuario model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("vusuario", model.login);
                pairs.Add("vcontrasenia", model.contraseña);
                System.Net.Http.FormUrlEncodedContent a = new FormUrlEncodedContent(pairs);
                HttpResponseMessage res = await client.PostAsync("api/login/", a);
                if (res.IsSuccessStatusCode)
                {
                    var JsonResponse = res.Content.ReadAsStringAsync().Result;                    
                    Datos.Models.Seguridad.Sesion objsesion =JsonConvert.DeserializeObject< Datos.Models.Seguridad.Sesion>(JsonResponse);
                    if (objsesion.msg.Equals("OK"))
                    {
                        HttpContext.Session.Set<Datos.Models.Seguridad.Sesion>("sesion", objsesion);
                        return RedirectToAction("Index", "Principal");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Inicio");
                    }                                                                            
                }
                else
                {
                    return RedirectToAction("Index", "Inicio");
                }
            }
        }


    }



}
