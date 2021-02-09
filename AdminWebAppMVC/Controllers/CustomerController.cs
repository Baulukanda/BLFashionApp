using AdminWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminWebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        // API BaseUrl
        Uri baseApiUrl = new Uri("https://localhost:44380/api");
        HttpClient client;

        public CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseApiUrl;
        }
        // GET: Customer
        public ActionResult GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            HttpResponseMessage respsonse = client.GetAsync(client.BaseAddress + "/customer").Result;
            if (respsonse.IsSuccessStatusCode)
            {
                string data = respsonse.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
            return View(customers);
        }

        // POST: Customer/create
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            string data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/customer", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCustomers");
            }
            return View();
        }

        // PUT: Customer/id
        [HttpPut]
        public ActionResult EditCustomer(int id)
        {
            Customer customer = new Customer();
            HttpResponseMessage respsonse = client.GetAsync(client.BaseAddress + "/customer/" + id).Result;
            if (respsonse.IsSuccessStatusCode)
            {
                string data = respsonse.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
            return View(customer);
        }

        public ActionResult EditCustomer(Customer customer)
        {
            string data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data, Encoding.UTF8, "Application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/customer/" + customer.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCustomers");
            }
            return View(customer);
        }


        // DELETE: Customer/id
        public ActionResult DeleteCustomer(int id)
        {
            HttpResponseMessage respsonse = client.DeleteAsync(client.BaseAddress + "/customer/" + id).Result;
            if (respsonse.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCustomers");
            }
            return RedirectToAction("DeleteCustomer");
        }
    }
}
