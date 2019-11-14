using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TestSyntCli.Models;

namespace TestSyntCli.Controllers
{
    public class AppController : Controller
    {

        private readonly ILogger<HomeController> logger;
        private readonly IConfiguration configuration;
        private readonly IApiClient apiClient;


       public AppController(ILogger<HomeController> logger, IConfiguration configuration, IApiClient apiClient) {
            this.logger = logger;
            this.configuration = configuration;
            this.apiClient = apiClient;
        }


        // GET: App
        public async Task<ActionResult> IndexAsync()
        {
            
            var endpoint = new Uri(configuration["ServicesURL"] + "App" );
            List<AppModel>  list = await apiClient.GetAsync<List<AppModel>>(endpoint);
            return View(list);

        }

        // GET: App/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
           
            var endpoint = new Uri(configuration["ServicesURL"] + "App/" + id.ToString());
            AppModel data = await apiClient.GetAsync<AppModel>(endpoint);
            return View(data);
        }

        // GET: App/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: App/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AppModel data)
        {
            try
            {
                var endpoint = new Uri(configuration["ServicesURL"] + "App");
                MessageModel message =  await apiClient.PostAsync<AppModel>(endpoint, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var endpoint = new Uri(configuration["ServicesURL"] + "App/" + id.ToString());
            AppModel data = await apiClient.GetAsync<AppModel>(endpoint);
            return View(data);

        }

        // POST: App/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, AppModel data)
        {
            try
            {
                  using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PutAsync(configuration["ServicesURL"] + "App/", content))
                        {

                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
            catch
            {
                return View();
            }
        }

        // GET: App/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var endpoint = new Uri(configuration["ServicesURL"] + "App/" + id.ToString());
            AppModel data = await apiClient.GetAsync<AppModel>(endpoint);
            return View(data);
        }

        // POST: App/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}