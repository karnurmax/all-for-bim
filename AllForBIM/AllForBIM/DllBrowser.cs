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

        internal IEnumerable<string> GetAllNamespaces()
        {
            var types = assembly.ExportedTypes;

            return types.Select(t => t.Namespace)
                .Distinct();

        }
        internal IEnumerable<string> GetAllTypesOfNamespace(string nameSpace)
        {
            return assembly.ExportedTypes.Where(t => t.Namespace == nameSpace).Select(t => t.FullName);
        }

        internal IEnumerable<MemberInfo> getAllMembersOfType(string typeName)
        {
            var t = assembly.ExportedTypes.FirstOrDefault(c => c.FullName == typeName);
            if (t == null)
                return null;
            return t.GetMembers();
        }
    }
}
