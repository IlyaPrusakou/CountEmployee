using DataLayer;
using InterfaceCore;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountEmployee.Controllers
{
    
    public class Employees: Controller
    {

        private IXmlEngine _dataEngine { get; set; }
        private IFilePath MyPath { get; set; }
        public Employees(IXmlEngine engine, IFilePath mypath)
        {
            _dataEngine = engine;
            MyPath = mypath;
        }
        
        [Route("ShowEmployees")]
        public IActionResult ShowEmployees()
        {
            _dataEngine.DataSet = new List<Employee>();
            _dataEngine.LoadDataFromXml(@MyPath.Path); //@"D:\ДЗ\systemtech"
            List<Employee> Employees = _dataEngine.DataSet;
            return View("~/Views/Employees/ShowEmployees.cshtml", Employees);
        }
        private Authority CheckAuthorityEnumWithString(string AuthorityString)
        {
            Authority result = Authority.Developer; // просто заглушка
            switch (AuthorityString)
            {
                case "Seo":
                    result = Authority.Seo;
                    break;
                case "Sales":
                    result = Authority.Sales;
                    break;
                case "Hr":
                    result = Authority.Hr;
                    break;
                case "Developer":
                    result = Authority.Developer;
                    break;
            }
            return result;
        }
        private Department GetDepatment(List<Employee> list, string NameOfDepartment)
        {
            Employee emp = list.First(employee => employee.Department.NameOfDepartment == NameOfDepartment);
            Department result = emp.Department;
            return result;
        }
        [HttpGet]
        [Route("UpdateEmployees")]
        public IActionResult UpdateEmployees()
        {
            _dataEngine.DataSet = new List<Employee>();
            _dataEngine.LoadDataFromXml(@MyPath.Path);
            List<Employee> Employees = _dataEngine.DataSet;
            return View("~/Views/Employees/UpdateEmployees.cshtml", Employees);
        }

        [HttpPost]
        [Route("UpdateEmployees")]
        public IActionResult UpdateEmployees(int Id, string FullName,
            string DateOfCreation, string DateOfChange, string DateOfHiring,
            string Authority, string NameOfDepartment)
        {
            _dataEngine.DataSet = new List<Employee>();
            _dataEngine.LoadDataFromXml(@MyPath.Path);
            Employee emp = new Employee();
            emp.Id = Id;
            emp.FullName = FullName;
            emp.DateOfCreation = DateOfCreation;
            emp.DateOfChange = DateOfChange;
            emp.DateOfHiring = DateOfHiring;
            emp.Authority = CheckAuthorityEnumWithString(Authority);
            emp.Department = GetDepatment(_dataEngine.DataSet, NameOfDepartment);
            _dataEngine.DataSet.Add(emp);
            List<Employee> Employees = _dataEngine.DataSet;
            string FullFileName = MyPath.Path + @"\" + MyPath.FileName;
            _dataEngine.SaveDataToXml(@FullFileName); //@"D:\ДЗ\systemtech\Employees.xml"
            return View("~/Views/Employees/ShowEmployees.cshtml", Employees);
        }
        [Route("DeleteEmployees")]
        public IActionResult DeleteEmployees()
        {
            return View();
        }

    }
}
