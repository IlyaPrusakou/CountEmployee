using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceCore
{
    public interface IXmlEngine
    {
        List<Employee> DataSet { get; set; }
        List<Department> ExtractedDepartments { get; set; }
        void SaveDataToXml(string filepath);
        void LoadDataFromXml(string directoryPath);
    }
}
