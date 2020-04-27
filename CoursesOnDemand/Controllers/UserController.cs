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
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Initializing de static list of objects
        public UserController()
        {
            PersisteContext.Students = (PersisteContext.Students == null) ? new List<Student>() : PersisteContext.Students;
        }

        /// <summary>
        /// Save a student/user register
        /// </summary>
        /// <param name="value"></param>
        //POST: api/Student
        [HttpPost]
        public void Post(Student value)
        {
            StudentController.InitializeStudentRegister(value);
            //Saving object
            PersisteContext.Students.Add(value);
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
                StudentController.InitializeStudentRegister(value);
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
        /// Do Login Method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("/user/login")]
        public IActionResult Login([FromBody]UserLoginModel value)
        {
            Student user = (from s in PersisteContext.Students where s.Login != null && s.Login.Equals(value.Email) && s.Password.Equals(value.Password) select s).FirstOrDefault();
            if (user != null)
            {
                user.Token = new Random().Next(10000, 99999).ToString();
                return Ok(user);
            }
            return BadRequest("Not Authorized!");
        }
    }
}
