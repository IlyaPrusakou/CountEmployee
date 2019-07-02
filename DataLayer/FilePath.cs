using System;
using System.Collections.Generic;
using System.Text;
using InterfaceCore;

namespace DataLayer
{
    public class FilePath: IFilePath
    {
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}
