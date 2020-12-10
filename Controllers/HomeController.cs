using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BindingGrid.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //var mvcName = typeof(Controller).Assembly.GetName();
            //var isMono = Type.GetType("Mono.Runtime") != null;

            //ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            //ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            List<BindingGrid.Models.Value> model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://wbwcfe.worldbank.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  

                HttpResponseMessage response = await client.GetAsync("indc/odata/Viw_A_InitialLoading");
                if (response.IsSuccessStatusCode)
                {
                    var countryDetail = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BindingGrid.Models.OData>(countryDetail).Value;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return View(model);
        }
    }


}
