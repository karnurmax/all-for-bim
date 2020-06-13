using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AllForBIM
{
    internal class DllBrowser
    {
        private readonly string revitAPIDllPath;
        private readonly Assembly assembly;

        public DllBrowser(string revitAPIDllPath)
        {
            this.revitAPIDllPath = revitAPIDllPath;
            var bytes = File.ReadAllBytes(this.revitAPIDllPath);
            this.assembly = Assembly.LoadFile(this.revitAPIDllPath);
        }

        internal IEnumerable<string> GetAllClasses()
        {
            var types = assembly.ExportedTypes;

            return types.Select(t => t.Namespace)
                .Distinct();

        }
    }
}
