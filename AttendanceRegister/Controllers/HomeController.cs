using AttendanceRegister.Data;
using AttendanceRegister.Migrations;
using AttendanceRegister.Models;
using AttendanceRegister.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceRegister.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var attendanceRecords = _dbContext.AttendanceRecords.ToList();

            return View(attendanceRecords);
        }

        public IActionResult AddAttendance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAttendance(AttendanceRecord attendanceRecord)
        {
            if (ModelState.IsValid)
            {

                _dbContext.Add(attendanceRecord);
                _dbContext.SaveChanges();

                 return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Record not found.");
            return View("AddAttendance", attendanceRecord);
        }

        private List<AttendanceReportViewModel> GetAttendanceReport(List<AttendanceRecord> attendanceRecords)
        {
            //logic to generate the report data
            // Calculate the number of classes attended and missed for each student

            var reportData = attendanceRecords
                .GroupBy(record => new { record.ClassName, record.Grade, record.StudentName })
                .Select(group => new AttendanceReportViewModel
                {
                    ClassName = group.Key.ClassName,
                    Grade = group.Key.Grade,
                    StudentName = group.Key.StudentName,
                    ClassesAttended = group.Count(record => record.IsPresent),
                    ClassesMissed = group.Count(record => !record.IsPresent),
                })
                .ToList();

            return reportData;
        }
        public IActionResult AttendanceReport()
        {
            // Retrieve attendance data from the database
            var attendanceRecords = _dbContext.AttendanceRecords.ToList();

            // Perform necessary calculations to generate the report
            var reportData = GetAttendanceReport(attendanceRecords);
            return View(reportData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
