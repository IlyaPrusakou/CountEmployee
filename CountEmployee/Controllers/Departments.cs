using InterfaceCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountEmployee.Controllers
{
    public class Departments: Controller
    {
        private IXmlEngine _dataEngine { get; set; }
        public Departments(IXmlEngine engine)
        {
            _dataEngine = engine;
        }
        [Route("ShowDepartments")]
        public IActionResult ShowDepartments()
        {
            return View();
        }
        [Route("UpdateDepartments")]
        public IActionResult UpdateDepartments()
        {
            return View();
        }
        [Route("DeleteDepartments")]
        public IActionResult DeleteDepartments()
        {
            return View();
        }

    }
}
