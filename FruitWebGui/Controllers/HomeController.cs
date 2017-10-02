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
            ServiceApiConnection apiHelper = new ServiceApiConnection();

            if (Session["ItemsInBasket"] != null)
            {

                string[] items = Session["ItemsInBasket"].ToString().Split(',');
                List<CartableItem> cartItems = new List<CartableItem>();

                foreach (string item in items)
                {
                    string[] itemProperties = item.ToString().Split(':'); 
                    Fruit fruit = (Fruit)apiHelper.GetFruitById(int.Parse(itemProperties[0]));
                    int price = fruit.price * int.Parse(itemProperties[1]);
                    CartableItem itemForCart = new CartableItem(int.Parse(itemProperties[0]), int.Parse(itemProperties[1]), fruit.Name, price);
                    cartItems.Add(itemForCart); 
                }

                ViewBag.Cart = cartItems;
            }


            ViewBag.Fruits = (List<Fruit>)apiHelper.GetAllFruits();

            return View();
        }

        public ActionResult AddItem(int fruitID, int Amount)
        {

            // add item as json to cookies
            
            if (Session["ItemsInBasket"] == null)
            {

                Session["ItemsInBasket"] =  fruitID + ":" + Amount ;
            }
            else
            {
                Session["ItemsInBasket"] += "," + fruitID + ":" + Amount;
            }


    

            return RedirectToAction("Index");
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