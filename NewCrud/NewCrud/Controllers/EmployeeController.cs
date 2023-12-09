using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using NewCrud.Models;
using NewCrud.Services.Employees;

namespace NewCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env, IEmployeeRepository employeeRepository)
        {
            _configuration = configuration;
            _env = env;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("getallemployeedetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmpDetails()
        {
            var employees = _employeeRepository.GetEmployees();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(employees);
        }
        /*
        [HttpPost("registeremployee")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult RegisterEmployee([FromBody])
        */
        /*
        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            string q = @"update employee set ename = @ename, deptname = @deptname, dateofjoining = @dateofjoining, photofilename = @photofilename where eid = @eid";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    myCommand.Parameters.AddWithValue("@eid", emp.eid);
                    myCommand.Parameters.AddWithValue("@ename", emp.ename);
                    myCommand.Parameters.AddWithValue("@deptname", emp.deptname);
                    myCommand.Parameters.AddWithValue("@dateofjoining", emp.dateofjoining);
                    myCommand.Parameters.AddWithValue("@photofilename", emp.photofilename);
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated successfully!");

        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string q = @"delete from employee where eid = @eid";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    myCommand.Parameters.AddWithValue("@eid", id);
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted successfully!");

        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch(Exception)
            {
                return new JsonResult("error.png");
            }
        }
        */
    }
}
