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
        ServiceApiConnection apiHelper = new ServiceApiConnection();
        public ActionResult Index()
        {
            try
            {

                if (TempData["purchased"] != null) // if user is checking out , these will not be null
                {
                    ViewBag.purchased = true;
                }
                else if (TempData["Error"] != null) // if an error occurred when redirecting from another action
                {
                    ViewBag.errorMsg = TempData["Error"];
                }

                if (Session["ItemsInBasket"] != null) 
                {
                    ViewBag.Cart = getCartItems(); // get items from cart
                    ViewBag.totSum = 0;
                    foreach (CartableItem item in ViewBag.Cart)
                    {
                        ViewBag.totSum += item.price;
                    }

                }
                if (TempData["InitPurchase"] != null) // if checkout was initiated
                {
                    ViewBag.InitPurchase = true;
                }

                ViewBag.Fruits = (List<Fruit>)apiHelper.GetAllFruits(); // gets list of fruits from API
            }

            catch (Exception ex)
            {
                ViewBag.errorMsg = ex.Message;
            }
            return View();
        }


        public List<CartableItem> getCartItems()
        {
            List<CartableItem> cartables = new List<CartableItem>();

            string[] items = Session["ItemsInBasket"].ToString().Split(',');

            foreach (string item in items)
            {
                string[] itemProperties = item.ToString().Split(':'); //index 0 is ID and index 1 is amount
                Fruit fruit = (Fruit)apiHelper.GetFruitById(int.Parse(itemProperties[0]));
                int price = fruit.price * int.Parse(itemProperties[1]);
                CartableItem itemForCart = new CartableItem(int.Parse(itemProperties[0]), int.Parse(itemProperties[1]), fruit.Name, price);
                cartables.Add(itemForCart);
            }
            return cartables;
        }

        public ActionResult AddItem(int fruitID, int Amount)
        {

            try
            {
                // add item as json to cookies

                if (Session["ItemsInBasket"] == null)
                {

                    Session["ItemsInBasket"] = fruitID + ":" + Amount;
                }
                else
                {
                    Session["ItemsInBasket"] += "," + fruitID + ":" + Amount;
                }
            }
            catch (Exception ex)
            {
                ViewBag.errorMsg = ex.Message;
            }


            return RedirectToAction("Index");
        }

        public ActionResult InitPurchase()
        {
            TempData["InitPurchase"] = true;
            return RedirectToAction("Index");
        }


        public ActionResult PurchaseItems()
        {
            try
            {
                List<ContentOfOutgoingTransaction> transactionItems = new List<ContentOfOutgoingTransaction>();

                // get cookie and loop through
                List<CartableItem> cart = getCartItems();
                foreach (CartableItem item in cart)
                {
                    transactionItems.Add(new ContentOfOutgoingTransaction(item.id, item.amount));
                }
                if (transactionItems.Count < 1)
                {
                    throw new Exception("Cart is Empty");
                }
                
                if (apiHelper.MakePurchase(transactionItems))
                {
                    TempData["purchased"] = true;
          
                }
                else
                {
                    throw new Exception("Could not make purchase");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            Session["ItemsInBasket"] = null;
            return RedirectToAction("Index");
        }

    }
}