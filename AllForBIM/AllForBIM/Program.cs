using System;
using System.Collections.Generic;
using System.Linq;

namespace AllForBIM
{
    class Program
    {
        static void Main(string[] args)
        {
            var revitAPIDllPath = @"C:\Program Files\Autodesk\Revit 2021\RevitAPI.dll";
            var revitAPIUIDllPath = @"C:\Program Files\Autodesk\Revit 2021\RevitAPIUI.dll";
            DllBrowser dllBrowser = new DllBrowser(revitAPIDllPath);
            List<string> allClasses = dllBrowser.GetAllClasses().ToList();
            allClasses.ForEach(cl => Console.WriteLine(cl));
            Console.Write("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
