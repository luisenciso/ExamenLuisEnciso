using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebAppBanco.Controllers
{
    public class OrdenPagoController : Controller
    {
        string url = "http://localhost:55033/";

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ListadoOrdenesPago()
        {
            List<Datos.Models.OrdenPago> lstOp = new List<Datos.Models.OrdenPago>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                /*
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("vusuario", model.login);
                pairs.Add("vcontrasenia", model.contraseña);
                System.Net.Http.FormUrlEncodedContent a = new FormUrlEncodedContent(pairs);
                */
                HttpResponseMessage res = await client.PostAsync("api/OrdenPago/", null);
                if (res.IsSuccessStatusCode)
                {
                    var JsonResponse = res.Content.ReadAsStringAsync().Result;
                    lstOp = JsonConvert.DeserializeObject<List<Datos.Models.OrdenPago>>(JsonResponse);                    
                }
                else
                {
                    //return RedirectToAction("Index", "Inicio");
                }
            }
            return View(lstOp);
        }
    }
}