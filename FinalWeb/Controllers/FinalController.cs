
using Exam.Irepository.ISport;
using Final.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FinalWeb.Controllers
{
    public class FinalController : Controller
    {
        Uri baseadd = new Uri("http://localhost:5280/api");
        HttpClient client;

        private readonly IWebHostEnvironment _environment;
        public FinalController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseadd;
        }
        public async Task<IActionResult> EntryForm()
        {
            string data = null;
            HttpResponseMessage response1 = client.GetAsync(client.BaseAddress + "/APIFinal/BatchBind").Result;
            HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/APIFinal/TechnologyBind").Result;
            if (response1.IsSuccessStatusCode)
            {
                data = response1.Content.ReadAsStringAsync().Result;
                List<Model> lstBatch = new List<Model>();
                lstBatch = JsonConvert.DeserializeObject<List<Model>>(data);
                lstBatch.Insert(0, new Model { Batch_id = 0, Batch_Name = "Please Select Batch" });
                ViewBag.Batch = lstBatch;
            }
            if (response2.IsSuccessStatusCode)
            {
                data = response2.Content.ReadAsStringAsync().Result;
                List<Model> lstTechnology = new List<Model>();
                lstTechnology = JsonConvert.DeserializeObject<List<Model>>(data);
                lstTechnology.Insert(0, new Model { Technology_id = 0, Teeechnology_Name = "Please Select Technology" });
                ViewBag.Technology = lstTechnology;
            }
            return View();
        }
        public async Task<JsonResult> Employee_Bind(int Batch_id, int Technology_id)
        {
            string data = null;
            string jsonres = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/APIFinal/EmployeeBind?Batch_id=" + Batch_id + "&Technology_id=" + Technology_id).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                List<Model> lstBatch = new List<Model>();
                lstBatch = JsonConvert.DeserializeObject<List<Model>>(data);
                List<SelectListItem> scalist = new List<SelectListItem>();
                foreach (Model dr in lstBatch)
                {
                    scalist.Add(new SelectListItem { Text = dr.Employee_Name, Value = dr.Employee_id.ToString() });
                }
                jsonres = JsonConvert.SerializeObject(scalist);
            }
            return Json(jsonres);
        }


        [HttpPost]
        public async Task<JsonResult> SaveMark(Model markval)
        {
            var result = 0;
            if (markval.empid == 0)
            {
                return Json(1);
            }
            else if (markval.mark == 0)
            {
                return Json(2);
            }
            else
            {
                string getdata = null;
                string data = JsonConvert.SerializeObject(markval);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/APIFinal/SaveMark", content).Result;
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);
                if (response.IsSuccessStatusCode)
                {
                    string data1 = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<int>(data1);
                }
                return Json(result);
            }
        }


        public async Task<JsonResult> ViewReport(int Batch_id)
        {
            List<Model> lstBatch = new List<Model>();
            string data = null;
            string jsonres = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/APIFinal/ViewReport?Batch_id=" + Batch_id).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                lstBatch = JsonConvert.DeserializeObject<List<Model>>(data);
            }
             jsonres = JsonConvert.SerializeObject(lstBatch);
           
            return Json(jsonres);
        }
    }
}
