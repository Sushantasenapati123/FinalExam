using Exam.Domain.Sports;
using Exam.Irepository.ISport;
using Final.Model.Entity;
using Final_Irepository.IModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Dapper.SqlMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIFinalController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IEntity log;
        public APIFinalController(IEntity _log, IWebHostEnvironment environment)
        {
            _environment = environment;
            log = _log;
            
        }
        [HttpGet("BatchBind")]
        public async Task<IEnumerable<Model>> BatchBind()
        {

            return  await log.BatchBind();

        }
        
        [HttpGet("TechnologyBind")]
        public async Task<IEnumerable<Model>> TechnologyBind()
        {

            return await log.TechnologyBind();

        }
        [HttpGet("EmployeeBind")]
        public async Task<IEnumerable<Model>> EmployeeBind(int Batch_id, int Technology_id)
        {
            return await log.EmployeeBind(Batch_id,Technology_id);

        }


        [HttpPost("SaveMark")]
        public async Task<ActionResult<int>> SaveMark(Model custe)
        {

            return await log.SaveMark(custe);

        }
        [HttpGet("ViewReport")]
        public IActionResult ViewReport( int Batch_id)
        {
            var Doctors = log.ViewReport(Convert.ToInt32(Batch_id)).Result;
            return Ok(JsonConvert.SerializeObject(Doctors));
        }




        //[HttpPost("DeleteAccounts")]
        //public IActionResult DeleteAccounts(AccountEntity id)
        //{
        //    var Retval = _iacc.DeleteAccount(id.Account_id);
        //    return Ok(Retval);
        //}

    }
}
