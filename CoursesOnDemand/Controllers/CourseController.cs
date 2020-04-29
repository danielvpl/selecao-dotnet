using System.Collections.Generic;
using System.Linq;
using CoursesOnDemand.Domain;
using CoursesOnDemand.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoursesOnDemand.Controllers
{
    /// <summary>
    /// Course API Controller
    /// </summary>
    [Route("Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //Initializing de static list of objects
        public CourseController()
        {
            FakeRepository.Courses = FakeRepository.Courses == null ?
                new List<Course>() { 
                    new Course() { Id = 1, Title = ".NET Core C#", Description = ".NET Core C# Course" },
                    new Course() { Id = 2, Title = "Angular 8", Description = "Angular 8 Course" },
                    new Course() { Id = 3, Title = "EntityFramework", Description = "EntityFramework Course" },
                    new Course() { Id = 4, Title = "Scrum Methodology", Description = "Scrum Methodology Course" }
                }               
            : FakeRepository.Courses;
        }

        /// <summary>
        /// List all courses list
        /// </summary>
        /// <returns></returns>
        // GET: api/Course
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return FakeRepository.Courses;
        }

        /// <summary>
        /// Get a course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Course/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return (from s in FakeRepository.Courses where s.Id == id select s).FirstOrDefault();
        }

        /// <summary>
        /// Save a course register
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Course
        [HttpPost]
        public void Post(Course value)
        {
            FakeRepository.Courses.Add(value);
        }

        /// <summary>
        /// Insert or update course registers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Course/5
        [HttpPut("{id}")]
        public void Put(int id, Course value)
        {
            var forUpdate = FakeRepository.Courses.Where(c => c.Id == id).ToList();
            forUpdate.ForEach(c =>
            {
                c.Title = value.Title;
                c.Description = value.Description;                
            });
        }

        /// <summary>
        /// Delete a course register
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            FakeRepository.Courses.RemoveAll((x) => x.Id == id);
        }
    }
}
