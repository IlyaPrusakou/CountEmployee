using InterfaceCore;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataLayer
{
    public class XmlEngine: IXmlEngine
    {
        public List<Employee> DataSet { get; set; }
        public List<Department> ExtractedDepartments { get; set; }
        
        public void ExtractData(string filepath)
        {
            using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (XmlReader rdr = XmlReader.Create(fs))
                {
                    XDocument doc = XDocument.Load(rdr);
                    XElement rootElement = doc.Root;
                    IEnumerable<XElement> Departments = rootElement.Descendants("Department");
                    
                    foreach (XElement item in Departments)
                    {
                        Department dep = new Department
                        {
                            Id = Convert.ToInt32(item.Element("Id").Value),
                            NameOfDepartment = item.Element("NameOfDepartment").Value,
                            DateOfDepartmentChange = item.Element("DateOfDepartmentChange").Value,
                            DateOfDepartmentCreation = item.Element("DateOfDepartmentCreation").Value
                        };
                        ExtractedDepartments.Add(dep);
                    }
                }
            }
        }

        public void SaveDataToXml(string filepath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            using (FileStream fs = File.Create(filepath))
            {
                using (XmlWriter str = XmlWriter.Create(fs, set))
                {
                    xs.Serialize(str, DataSet);
                }
            }

        }
        private List<Employee> DeserializeClass(FileInfo file, XmlSerializer xs)
        {
            List<Employee> item;
            using (FileStream fs = new FileStream(file.FullName, FileMode.Open))
            {
                using (XmlReader rdr = XmlReader.Create(fs))
                {
                    item = (List<Employee>)xs.Deserialize(rdr);
                }
            }
            return item;
        }
        public void LoadDataFromXml(string directoryPath)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            FileInfo[] files = dir.GetFiles("*.xml*");
            List<Employee> listOfLoadedItems = new List<Employee>();
            List<Employee> item = default;
            foreach (FileInfo file in files)
            {
                try
                {

                    item = DeserializeClass(file, xs);

                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File has not found");
                }
            }
            DataSet = item;
        }

    }
}
