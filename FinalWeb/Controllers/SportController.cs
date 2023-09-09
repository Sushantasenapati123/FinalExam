
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Exam.Domain.Sports;
using Exam.Irepository.ISport;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Exam.Web.Controllers
{//Sport_Registration
   
    public class SportController : Controller
    {

        Uri baseadd = new Uri("http://localhost:5280/api");
        HttpClient client;

        private readonly IWebHostEnvironment _environment;
        private readonly SpotInterface log;
        private readonly IHttpClientFactory _httpClientFactory;


        public SportController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseadd;
        }
      
        public async Task<IActionResult> Sport_Registration()
        {
            try
            {
                List<Spot> pc1 = new List<Spot>();
                HttpResponseMessage response1 = client.GetAsync(client.BaseAddress + "/APIFinal/bindClub").Result;
              
                if (response1.IsSuccessStatusCode)
                {
                    string data = response1.Content.ReadAsStringAsync().Result;
                    pc1 = JsonConvert.DeserializeObject<List<Spot>>(data);
                    pc1.Insert(0, new Spot { club_id = 0, club_name = "---Select---" });

                }
               
                ViewBag.UnitName = pc1;


                List<Spot> pc2 = new List<Spot>();
                HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/APIFinal/GetAll").Result;

                if (response2.IsSuccessStatusCode)
                {
                    string data = response2.Content.ReadAsStringAsync().Result;
                    pc2 = JsonConvert.DeserializeObject<List<Spot>>(data);
                   

                }



                ViewBag.Result = pc2;// await log.GetAll(new Spot());
              //  Log.Information("Sport_Registration");
                return View();
               
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message + "\n" + ex.StackTrace);
                return Json(0);
            }

        }
        public async Task<IActionResult> View_SportRegistration()
        {
            List<Spot> pc2 = new List<Spot>();
            HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/APIFinal/GetAll").Result;

            if (response2.IsSuccessStatusCode)
            {
                string data = response2.Content.ReadAsStringAsync().Result;
                pc2 = JsonConvert.DeserializeObject<List<Spot>>(data);
            }
            ViewBag.Result = pc2;
            return View();
        }
       
        [HttpPost]
        public async Task<JsonResult> Add(Spot entity)
        {
            string[] files = entity.image_path.Split('\\');
            entity.image_path = "prodimage/" + files[files.Length - 1];

            var result = 0;

            string data = JsonConvert.SerializeObject(entity);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response3;
            try
            {
                response3 = client.PostAsync(client.BaseAddress + "/APIFinal/Insert", content).Result;
                string errorResponse = await response3.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);

                if (response3.IsSuccessStatusCode)
                {
                    string data1 = response3.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<int>(data1);
                }
            }
            catch(Exception ex)
            {
                
            }
           

            int retMsg = result;// await log.insert(entity);

            if (retMsg == 1)
            {
                return Json("Record Saved Successfully");
            }
            else if (retMsg == 2)
            {
                return Json("Record Updated Successfully");
            }
            else if (retMsg == 5)
            {
                return Json("Age must Be Greater Than 13");
            }
            else
            {
                return Json("Record Already Exist");
            }



        }
        [HttpPost]
        public IActionResult UploadImage(IFormFile MyUploader)
        {
            if (MyUploader != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "prodimage");
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }
                return new ObjectResult(new { status = "success" });
            }
            return new ObjectResult(new { status = "fail" });

        }

        [HttpGet]
        public async Task<IActionResult> GetSubCatByCId(int clubid)
        {
            List<SportEntity> pc61 = new List<SportEntity>();
            HttpResponseMessage response12 = client.GetAsync(client.BaseAddress + "/APIFinal/BindByCatid?id=" + clubid).Result;
            if (response12.IsSuccessStatusCode)
            {
                string data = response12.Content.ReadAsStringAsync().Result;
                pc61 = JsonConvert.DeserializeObject<List<SportEntity>>(data);

            }
            var Slots = pc61;
            return Ok(JsonConvert.SerializeObject(Slots));
        }


        [HttpGet]
        public IActionResult MedicineGetById(int id)
        {
            Spot pc61 = new Spot();
            HttpResponseMessage response12 = client.GetAsync(client.BaseAddress + "/APIFinal/BetById?id=" + id).Result;
            if (response12.IsSuccessStatusCode)
            {
                string data = response12.Content.ReadAsStringAsync().Result;
                pc61 = JsonConvert.DeserializeObject<Spot>(data);

            }
            //var Slots = pc61;




           // var Doctors = log.GetById(Convert.ToInt32(id)).Result;



            return Ok(JsonConvert.SerializeObject(pc61));
        }


        //public void deathreportexcell(/*List<Registration_Details> data*/)
        //{
        //    using (var workbook = new XLWorkbook())
        //    {
        //        int count = 0;
        //        var worksheet = workbook.Worksheets.Add("Report");
        //        var currentRow = 1;

        //        worksheet.Cell(currentRow, 1).Value = "Sl. NO";
        //        worksheet.Cell(currentRow, 2).Value = "NAME";
        //        worksheet.Cell(currentRow, 3).Value = "Email";
        //        worksheet.Cell(currentRow, 4).Value = "MOBILE NO";
        //        worksheet.Cell(currentRow, 5).Value = "IMAGE";
        //        worksheet.Cell(currentRow, 6).Value = "CLUB NAME";
        //        worksheet.Cell(currentRow, 7).Value = "SPORTS NAME";


        //        List<Spot> data = log.GetAllExcelData(new Spot());


        //        foreach (var val in data)
        //        {
        //            {

        //                count = ++count;
        //                currentRow++;
        //                worksheet.Cell(currentRow, 1).Value = count;
        //                worksheet.Cell(currentRow, 2).Value = val.Applicant_name;
        //                worksheet.Cell(currentRow, 3).Value = val.Email;
        //                worksheet.Cell(currentRow, 4).Value = val.Mobile_no;

        //                worksheet.Cell(currentRow, 5).Value = val.image_path;
        //                worksheet.Cell(currentRow, 6).Value = val.club_name;
        //                worksheet.Cell(currentRow, 7).Value = val.sprot_name;


        //            }
        //        }
        //        var stream = new MemoryStream();
        //        workbook.SaveAs(stream);
        //        var content = stream.ToArray();
        //        Response.Clear();
        //        Response.Headers.Add("content-disposition", "attachment;filename=Report.xls");
        //        Response.ContentType = "application/xls";
        //        Response.Body.WriteAsync(content);
        //        Response.Body.Flush();
        //    }
        //}



    }
}
