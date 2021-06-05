using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TodoApi.Models;
using WebApplication.Helpers;

namespace WebApplication.Controllers
{
    public class AddressController : Controller
    {
        private ApiHelper _apiHelper;
        private HttpClient _client;

        public AddressController()
        {
            _apiHelper = new ApiHelper();
            _client = _apiHelper.Initial();
        }

        // GET: Address
        public async Task<IActionResult> Index(string filter, string sort)
        {
            List<Address> addresses = new List<Address>();
            HttpResponseMessage res = await _client.GetAsync("/api/Addresses");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                addresses = JsonConvert.DeserializeObject<List<Address>>(result);
            }

            //Todo ignore capital letters
            if (!String.IsNullOrEmpty(filter))
            {
                addresses = addresses.Where(s =>
                    s.Street.Contains(filter)
                    || s.Country.Contains(filter)
                    || s.City.Contains(filter)
                    || s.PostalCode.Contains(filter)
                    || s.HouseNumber.ToString().Contains(filter)
                ).ToList();
            }

            if (!String.IsNullOrEmpty(sort))
            {
                Address address = new Address();
                foreach (PropertyInfo prop in address.GetType().GetProperties())
                {
                    if (prop.Name.Equals(sort))
                    {
                        //TODO prop.name has to get the same as s.
                        addresses = addresses.OrderBy(s => prop.Name).ToList();
                        break;
                    }
                }
            }

            return View(addresses);
        }

        // GET: Address/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            Address addresses = new Address();
            HttpResponseMessage res = await _client.GetAsync("/api/Addresses/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                addresses = JsonConvert.DeserializeObject<Address>(result);
            }

            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // GET: Address/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,HouseNumber,PostalCode,City,Country")] Address address)
        {
            Address newAddress = new Address();
            StringContent content = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");
            HttpResponseMessage res = await _client.PostAsync("/api/Addresses/", content);

            if (res.IsSuccessStatusCode)
            {
                string apiResponse = await res.Content.ReadAsStringAsync();
                newAddress = JsonConvert.DeserializeObject<Address>(apiResponse);
            }

            return RedirectToAction("Index");
        }

        // GET: Address/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            Address address = new Address();
            HttpResponseMessage res = await _client.GetAsync("/api/Addresses/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                address = JsonConvert.DeserializeObject<Address>(result);
            }

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Street,HouseNumber,PostalCode,City,Country")] Address address)
        {
            //TODO
            return RedirectToAction("Index");
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            Address address = new Address();
            HttpResponseMessage res = await _client.GetAsync("/api/Addresses/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                address = JsonConvert.DeserializeObject<Address>(result);
            }

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var response = await _client.DeleteAsync("api/Addresses/" + id);

            return RedirectToAction("Index");
        }

        // GET: Distance
        public async Task<IActionResult> Distance ()
        {
            List<Address> addresses = new List<Address>();
            HttpResponseMessage res = await _client.GetAsync("/api/Addresses");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                addresses = JsonConvert.DeserializeObject<List<Address>>(result);
            }

            return View(addresses);
        }
    }
}
