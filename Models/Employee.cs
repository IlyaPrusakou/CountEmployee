using System;
using System.Collections.Generic;
using System.Text;


namespace Models
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DateOfCreation { get; set; }
        public string DateOfChange { get; set; }
        public string DateOfHiring { get; set; }
        public Authority Authority { get; set; }
        public Department Department { get; set; }

    }
}
