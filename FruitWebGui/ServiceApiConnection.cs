using FruitWebGui.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FruitWebGui
{
    public class ServiceApiConnection
    {
        string apiUrl;
        public ServiceApiConnection()
        {
            apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"].ToString();
        }

        public object GetFruitById(int fruitId)
        {
            Fruit fruit = new Fruit();

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(apiUrl + "/Fruits/GetFruit/" + fruitId).Result;
            using (HttpContent content = response.Content)
            {
                var json = content.ReadAsStringAsync().Result;
                fruit = JsonConvert.DeserializeObject<Fruit>(json);
            }
            if (response.IsSuccessStatusCode)
            {
                return fruit;

            }
            else
            {
                return false;
            }
        }

        public object GetAllFruits()
        {
            List<Fruit> fruits;

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(apiUrl + "/Fruits/GetFruit").Result;
            using (HttpContent content = response.Content)
            {
                var json = content.ReadAsStringAsync().Result;
                fruits = JsonConvert.DeserializeObject<List<Fruit>>(json);
            }
            if (response.IsSuccessStatusCode)
            {
                return fruits;

            }
            else
            {
                return false;
            }
        }
    }
}