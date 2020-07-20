using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        static private List<Job> jobs;
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = jobs;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 

        [HttpPost]
        public IActionResult Results(string searchTerm, string searchType)
        {
            ViewBag.columns = ListController.ColumnChoices;
            
            int jobCount = 0;

            if (String.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();
            } 
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                
            }

            jobCount = jobs.Count;

            ViewBag.term = searchTerm;
            ViewBag.type = searchType;
            ViewBag.jobs = jobs;
            ViewBag.jobCount = jobCount;
            return View("Index");
        }
    }
}
