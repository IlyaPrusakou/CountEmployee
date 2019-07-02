using System;
using System.Collections.Generic;
using System.Text;


namespace Models
{
    [Serializable]
    public class Department
    {
        public int Id { get; set; }
        public string NameOfDepartment { get; set; }
        public string DateOfDepartmentCreation { get; set; }
        public string DateOfDepartmentChange { get; set; }
    }
}
