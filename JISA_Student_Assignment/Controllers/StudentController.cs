using JISA_Student_Assignment.Entities;
using JISA_Student_Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JISA_Student_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudent()
        {
            try
            {
                return new ObjectResult(service.GetStudents());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentById/{id}")]

        public IActionResult GetStudentById(int id)
        {

            try
            {
                return new ObjectResult(service.GetStudentById(id));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }

      
        [HttpPost]
        [Route("AddStudent")]

        public IActionResult AddStudent([FromBody] Student student)
        {
            try

            {
                int result = service.AddStudent(student);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);

                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]

        public IActionResult UpdateStudent([FromBody] Student student)
        {
            try
            {
                int result = service.UpdateStudent(student);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       
        [HttpDelete]
        [Route("DeleteStudent/{id}")]


        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteStudent(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
