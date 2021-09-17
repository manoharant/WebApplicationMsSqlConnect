using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMsSqlConnect.Models;
using WebApplicationMsSqlConnect.Services;

namespace WebApplicationMsSqlConnect.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;

        private readonly IConfiguration _iconfiguration;


        public CourseController(CourseService _svc,IConfiguration _configuration)
        {
            _course_service = _svc;
            _iconfiguration = _configuration;
        }

        // The Index method is used to get a list of courses and return it to the view
        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCourses(_iconfiguration.GetConnectionString("SQLConnection"));
            return View(_course_list);
        }
    }
}
