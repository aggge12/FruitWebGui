using FruitWebGui.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FruitWebGui.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"].ToString();

            List<Fruit> fruits;

            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var stringContent = new StringContent(JsonConvert.SerializeObject(fruit), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(apiUrl + "/Fruits/GetFruit").Result;
            using (HttpContent content = response.Content)
            {
                var json = content.ReadAsStringAsync().Result;
                fruits = JsonConvert.DeserializeObject<List<Fruit>>(json);
            }
            if (response.IsSuccessStatusCode)
            {
              

            }
            else
            {
                
            }

            ViewBag.Fruits = fruits;

            return View();
        }

        public ActionResult AddItem(int fruitID, int Amount)
        {
            // Add Item To Cookies or something

            return Index();
        }

        public ActionResult PurchaseItems()
        {
            List<ContentOfOutgoingTransaction> transactionItems = new List<ContentOfOutgoingTransaction>();

            // get cookie and loop through

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            var stringContent = new StringContent(JsonConvert.SerializeObject(transactionItems), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync( "/Fruits/GetFruit",stringContent).Result;
            using (HttpContent content = response.Content)
            {
                var json = content.ReadAsStringAsync().Result;
                //fruits = JsonConvert.DeserializeObject<List<Fruit>>(json);
            }
            if (response.IsSuccessStatusCode)
            {


            }
            else
            {

            }
            return Index();
        }

    }
}