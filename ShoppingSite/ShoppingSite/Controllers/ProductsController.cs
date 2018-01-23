using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingBasket.Models;
using ShoppingSite.Models;

namespace ShoppingSite.Controllers
{
    public class ProductsController : Controller
    {
        string ApiUrl = "http://localhost:53750";

        // GET: Products
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                MediaTypeWithQualityHeaderValue contentType =
                    new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync
                    ("/api/products").Result;
                string stringData = response.Content.
                    ReadAsStringAsync().Result;
                List<Product> data =  JsonConvert.DeserializeObject
                    <List<Product>>(stringData);
                return View(data);
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            using (HttpClient client = new HttpClient())
            {
                return View();
            }
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price")] Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonConvert.SerializeObject(product);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,
                    "application/json");
                HttpResponseMessage response = client.PostAsync("/api/products", contentData).Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
        }
    
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = client.GetAsync("/api/products/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Product data = JsonConvert.DeserializeObject<Product>(stringData);
                return View(data);
            }
        }


        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Price")] Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                MediaTypeWithQualityHeaderValue contentType =
                    new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonConvert.SerializeObject(product);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("/api/products/" + product.ID,contentData).Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                return View(product);
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                MediaTypeWithQualityHeaderValue contentType =
                    new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                
                HttpResponseMessage response = client.DeleteAsync("/api/products/" + id).Result;
                TempData["Message"] = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                MediaTypeWithQualityHeaderValue contentType =
                    new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = client.GetAsync("/api/products/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Product data = JsonConvert.DeserializeObject<Product>(stringData);
                return View(data);
            }
        }

        private bool ProductExists(int id)
        {
            return false;
        }
    }
}
