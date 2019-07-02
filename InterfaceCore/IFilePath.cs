using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceCore
{
    public interface IFilePath
    {
        string Path { get; set; }
        string FileName { get; set; }
    }
}
