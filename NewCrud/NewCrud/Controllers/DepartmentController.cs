using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult RegisterDepartment([FromBody] DepartmentRegisterDto registerDepartment)
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

            if (!_departmentRepository.CreateDepartment(departmentMap))
            {
                ModelState.AddModelError("DepartmentError", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Department added successfully!");
        }

        [HttpGet("getalldepartments")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Department>))]
        public IActionResult GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(departments);
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

        [HttpPost]
        public JsonResult Post(Department dept)
        {
            string q = @"insert into department values (@deptName)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    myCommand.Parameters.AddWithValue("@deptName", dept.dname);
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added successfully!");

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

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string q = @"delete from department where did = @dID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    myCommand.Parameters.AddWithValue("@dID", id);
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted successfully!");

        }
        */
    }
}
