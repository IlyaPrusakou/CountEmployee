using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using InterfaceCore;

namespace CountEmployee.Controllers
{

    public class Menu : Controller
    {
        private IFilePath MyPath;
        public Menu(IFilePath path)
        {
            MyPath = path;
        }
        [Route("")]
        public IActionResult FirstPage(string Path, string FileName)
        {
            MyPath.Path = Path;
            MyPath.FileName = FileName;
            return View("~/Views/FirstPage.cshtml");
            
        }
        [Route("Index")]
        public IActionResult Index()
        {
            
            
            return View("~/Views/Index.cshtml");
        }

        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Redirect("~/ShowEmployees");
        }
        [Route("GetDepartments")]
        public IActionResult GetDepartments()
        {
            return Redirect("~/ShowDepartments");
        }

    }
}
