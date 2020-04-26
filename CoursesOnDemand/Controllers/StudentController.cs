using System;
using System.Collections.Generic;
using System.Linq;
using CoursesOnDemand.Domain;
using CoursesOnDemand.ViewModels;
using CoursesOnDemand.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoursesOnDemand.Controllers
{
    /// <summary>
    /// Student API Controller
    /// </summary>
    [Route("Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //Initializing de static list of objects
        public StudentController()
        {
            PersisteContext.Students = (PersisteContext.Students == null) ? new List<Student>() : PersisteContext.Students;
        }

        /// <summary>
        /// List all students list
        /// </summary>
        /// <returns></returns>
        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return PersisteContext.Students;
        }

        /// <summary>
        /// Get a student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Student/5
        [HttpGet("{id}")]
        public Student Get(long id)
        {
            return (from s in PersisteContext.Students where s.Id == id select s).FirstOrDefault();
        }

        /// <summary>
        /// Save a student register
        /// </summary>
        /// <param name="value"></param>
        //POST: api/Student
        [HttpPost]
        public void Post(Student value)
        {
            InitializeStudentRegister(value);
            //Saving object
            PersisteContext.Students.Add(value);
        }        

        /// <summary>
        /// Save credit card info and set payments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("/student/setcard/{id}")]
        public IActionResult SetCard(String id, CreditCard value)
        {
            long idstudent = long.Parse(id);
            Student user = (from s in PersisteContext.Students where s.Id == idstudent select s).FirstOrDefault();
            if (user != null)
            {
                //Adding Credit Card Info
                user.CreditCard = value;
                user.Payments.Add(
                    new Payment()
                    {
                        Id = user.Payments.Count + 1,
                        Valor = 14.90f,
                        DataTime = DateTime.Now
                    }
                    );
                return Ok(user);
            }
            return BadRequest("Profile information needs to be updated!");
        }

        /// <summary>
        /// Define student courses
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("/student/setcourse")]
        public IActionResult SetCourse([FromBody]StudentSetCourse value)
        {
            var user = (from s in PersisteContext.Students where s.Id == value.IdStudent select s).FirstOrDefault();
            if(user != null)
            {
                if(user.Payments == null || user.Payments.Count == 0)
                {
                    return BadRequest("The Student Made no Payment!");
                }
                Course course = (from c in PersisteContext.Courses where c.Id == value.IdCourse select c).FirstOrDefault();
                user.Course = course;
                return Ok(user);
            }
            return BadRequest("Profile information needs to be updated!");
        }

        /// <summary>
        /// Do Login Method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("/user/login")]
        public IActionResult Login([FromBody]UserLoginModel value)
        {
            Student user = (from s in PersisteContext.Students where s.Login != null && s.Login.Equals(value.Email) && s.Password.Equals(value.Password) select s).FirstOrDefault();
            if(user != null)
            {
                user.Token = new Random().Next(10000, 99999).ToString();
                return Ok(user);
            }
            return BadRequest("Not Authorized!");
        }

        /// <summary>
        /// Insert or update student registers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(long id, Student value)
        {
            var user = (from s in PersisteContext.Students where s.Id == id select s).FirstOrDefault();
            if (user == null)
            {
                InitializeStudentRegister(value);
                PersisteContext.Students.Add(value);
            }
            else
            {
                var forUpdate = PersisteContext.Students.Where(c => c.Id == id).ToList();
                forUpdate.ForEach(c =>
                {
                    c.FirstName = value.FirstName;
                    c.LastName = value.LastName;
                    c.Email = value.Email;
                    c.Phone = value.Phone;
                    c.CreditCard = value.CreditCard;
                    c.Course = value.Course;
                    c.Login = value.Email;
                    c.Password = value.Password;
                });
            }
        }

        /// <summary>
        /// Delete a student register
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PersisteContext.Students.RemoveAll((x) => x.Id == id);
        }

        public static void InitializeStudentRegister(Student value)
        {
            value.Id = PersisteContext.Students.Count + 1;
            value.Login = value.Email;
            //Initializing empty list of courses and payments
            value.Course = new Course() { Id = 0, Title = "", Description = ""};
            value.Payments = new List<Payment>();            
        }
    }
}
