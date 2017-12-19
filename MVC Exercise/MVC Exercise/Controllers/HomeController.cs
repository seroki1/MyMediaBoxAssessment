using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Exercise.Models;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace MVC_Exercise.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var parseXML = SerializeXML<ProjectModel>.ReadFromXML();
            var projects = (from a in parseXML.
                            select new ProjectModel
                            {
                                ProjectID = a.ProjectID,
                                ProjectNumber = a.ProjectNumber,
                                AllSubmissions = (from b in a.AllSubmissions
                                                  select new SubmissionModel
                                                  {
                                                      SubmissionID = b.SubmissionID,
                                                      SubmissionNumber = b.SubmissionNumber,
                                                      SubmissionType = b.SubmissionType,
                                                      ProjectID = b.ProjectID
                                                  }).ToList()

                            }).ToList();

            return View(projects);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
