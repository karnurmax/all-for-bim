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
            //var revitAPIUIDllPath = @"C:\Program Files\Autodesk\Revit 2021\RevitAPIUI.dll";
            DllBrowser dllBrowser = new DllBrowser(revitAPIDllPath);
            List<string> allNameSpaces = dllBrowser.GetAllNamespaces().ToList();
            int i = 0;
            allNameSpaces.ForEach(cl => Console.WriteLine($"{i++} = {cl}"));
            Console.Write("Выберите индекс пространства имен:");

            var nsName = allNameSpaces[int.Parse(Console.ReadLine())];
            Console.Clear();
            Console.WriteLine($"Выбранное пространство имен:{nsName}");
            var allTypesOfSelectedNS = dllBrowser.GetAllTypesOfNamespace(nsName).OrderBy(c => c).ToList();
            i = 0;
            allTypesOfSelectedNS.ForEach(c => Console.WriteLine($"{i++} = {c}"));

            Console.Write("Выберите индекс типа:");

            var typeName = allTypesOfSelectedNS[int.Parse(Console.ReadLine())];
            Console.Clear();
            Console.WriteLine($"Выбранный типа:{nsName}");

            var allMembers = dllBrowser.getAllMembersOfType(typeName).OrderBy(m => m.Name).ToList();
            i = 0;
            allMembers.ForEach(m => Console.WriteLine($"{i++} = \t[{m.MemberType}] = \t[{m.Name}]"));
            Console.Write("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
