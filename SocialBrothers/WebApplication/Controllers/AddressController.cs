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
using Newtonsoft.Json.Linq;
using TodoApi.Models;
using WebApplication.Helpers;
using WebApplication.Models;

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

            DistanceViewModel distanceViewModel = new DistanceViewModel()
            {
                Addresses = addresses
            };

            return View(distanceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Distance(DistanceViewModel distanceViewModel)
        {
            List<Address> addresses = new List<Address>();
            HttpResponseMessage res = await _client.GetAsync("/api/Addresses");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                addresses = JsonConvert.DeserializeObject<List<Address>>(result);
            }

            Address address1 = addresses.FirstOrDefault(item => item.Id == distanceViewModel.Addres1Id);
            Address address2 = addresses.FirstOrDefault(item => item.Id == distanceViewModel.Addres2Id);
            string addressFrom = "" + address1.Street + " " + address1.HouseNumber + " " + address1.PostalCode + " " + address1.City + " " + address1.Country;
            string addressTo = "" + address2.Street + " " + address2.HouseNumber + " " + address2.PostalCode + " " + address2.City + " " + address2.Country;

            DistanceViewModel newDistanceViewModel = new DistanceViewModel()
            {
                Addresses = addresses,
                Address1 = address1,
                Address2 = address2,
                Distance = GetDistance(addressFrom, addressTo)
            };

            return View(newDistanceViewModel);
        }

        public double GetDistance(string addressFrom, string addressTo)
        {
            double distance = 0;
            string key = "ce06124121561d6e2d30aaece6957972";
            string url1 = "http://api.positionstack.com/v1/forward?access_key=" + key + "&query=" + addressFrom;
            url1 = url1.Replace(" ", "+");
            string url2 = "http://api.positionstack.com/v1/forward?access_key=" + key + "&query=" + addressTo;
            url2 = url2.Replace(" ", "+");

            string content1 = FileGetContents(url1);
            string content2 = FileGetContents(url2);

            JObject object1 = JObject.Parse(content1);
            JObject object2 = JObject.Parse(content2);
            try
            {
                double latitude1 = (double)object1.SelectToken("data[0].latitude");
                double longitude1 = (double)object1.SelectToken("data[0].longitude");

                double latitude2 = (double)object2.SelectToken("data[0].latitude");
                double longitude2 = (double)object2.SelectToken("data[0].longitude");

                distance = CalculateDistance(latitude1, longitude1, latitude2, longitude2);

                return distance;
            }
            catch
            {
                return distance;
            } 
        }

        private string FileGetContents(string fileName)
        {
            string sContents;
            try
            {
                if (fileName.ToLower().IndexOf("http:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }

        private double CalculateDistance(double lat1, double long1, double lat2, double long2)
        {
            var d1 = lat1 * (Math.PI / 180.0);
            var num1 = long1 * (Math.PI / 180.0);
            var d2 = lat2 * (Math.PI / 180.0);
            var num2 = long2 * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return (6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) / 1000);
        }
    }
}
