using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace NewCrud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IConfiguration configuration, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _configuration = configuration;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpPost("registerdepartment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterDepartment([FromBody] DepartmentRegisterDto registerDepartment)
        {
            if (registerDepartment == null)
            {
                return BadRequest(ModelState);
            }

            if (registerDepartment.Name.Length == 0)
            {
                ModelState.AddModelError("DepartmentError", "Please fill all the fields.");
                return StatusCode(422, ModelState);
            }

            if (_departmentRepository.DepartmentExists(registerDepartment.Name))
            {
                ModelState.AddModelError("DepartmentError", "Department already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departmentMap = _mapper.Map<Department>(registerDepartment);

            var isCreated = await _departmentRepository.CreateDepartment(departmentMap);

            if (!isCreated)
            {
                ModelState.AddModelError("DepartmentError", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Department added successfully!");
        }

        [HttpGet]
        [Route("getalldepartments")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Department>))]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(departments);
        }

        [HttpGet]
        [Route("getdepartmentbyid/{id}")]
        [ProducesResponseType(200, Type = typeof(Department))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartment(id);

            if (department == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(department);
        }

        [HttpDelete]
        [Route("deletedepartmentbyid/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var isDeleted = await _departmentRepository.DeleteDepartment(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok("Deleted successfully!");

        }

        [HttpPut]
        [Route("updatedepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentRegisterDto departmentUpdate)
        {
            if (departmentUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (departmentUpdate.Name.Length == 0)
            {
                ModelState.AddModelError("DepartmentError", "Please fill all the fields");
                return StatusCode(422, ModelState);
            }

            var isUpdated = await _departmentRepository.UpdateDepartment(id, departmentUpdate);

            if (!isUpdated)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok("Updated successfully!");
        }

        /*
        [HttpGet]
        public JsonResult Get()
        {
            string q = @"select did, dname from department";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(q, myCon)) 
                {
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            //string temp = JsonConvert.SerializeObject(table);

            return new JsonResult(table);

        }

        [HttpPut]
        public JsonResult Put(Department dept)
        {
            string q = @"update department set dname = @deptName where did = @dID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    myCommand.Parameters.AddWithValue("@dID", dept.did);
                    myCommand.Parameters.AddWithValue("@deptName", dept.dname);
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated successfully!");

        }

        
        */
    
    }
}
