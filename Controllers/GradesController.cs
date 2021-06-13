using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly GradesDbContext _context;


        public GradesController(IConfiguration configuration, GradesDbContext context)
        {
            _configuration = configuration;
            _context = context;

        }
        // public IEnumerable<StudentsGrades> GetGrades()

        // GET: api/<GradesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsGrades>>> GetGrades()
        {
            //string query = @"  
            //        select studentID, studentFN, studentLN
            //        from dbo.Students";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("DevConnection");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader); ;

            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new string[] { "value1", "value2" };
            //var blogs = await _context.Blogs.Where(b => b.Rating > 3).ToListAsync();
            var studentsGrades = from grade in _context.Grades
                         join student in _context.Students on grade.studentID equals student.studentID
                         join Subject in _context.Subjects on grade.subjectID equals Subject.subjectID
                         select new 
                         {
                             GradeID = grade.gradeID,
                             FirstName = student.studentFN,
                             LastName = student.studentLN,
                             Subject = Subject.subjectName,
                             Grade = grade.grade
                         };
            foreach (var studentsGrade in studentsGrades)
            {

                Console.WriteLine($"\"{studentsGrade.FirstName}\" is owned by {studentsGrade.LastName + ' ' + studentsGrade.Grade}");
            }

            return  new JsonResult(studentsGrades);
        }

        // GET api/<GradesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GradesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GradesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GradesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
