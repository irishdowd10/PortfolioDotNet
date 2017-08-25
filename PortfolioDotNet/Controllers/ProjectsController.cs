using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioDotNet.Controllers;
using PortfolioDotNet.Models;


namespace PortfolioDotnet.Controllers
{
	public class ProjectsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetProjects()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GetProjects(Projects name, Projects html_url)
		{
			List<Projects> projectList = Projects.GetProjects();

			return View(projectList);
		}
	}
}