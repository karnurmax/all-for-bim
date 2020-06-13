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

        internal IEnumerable<string> GetAllNamespaceNames()
        {
            var types = assembly.ExportedTypes;

            return types.Select(t => t.Namespace)
                .Distinct();

        }
        internal IEnumerable<string> GetAllTypeNamesByNSName(string nameSpace)
        {
            return assembly.ExportedTypes.Where(t => t.Namespace == nameSpace).Select(t => t.FullName);
        }
        internal IEnumerable<MemberInfo> GetAllMemberNamesByTypeName(string typeName)
        {
            var t = assembly.ExportedTypes.FirstOrDefault(c => c.FullName == typeName);
            if (t == null)
                return null;
            return t.GetMembers();
        }

        internal List<string> GetMethodFullInfo(string typeName, MemberInfo methodInfo)
        {
            var t = assembly.ExportedTypes.FirstOrDefault(x => x.FullName == typeName);
            MemberInfo member = t.GetMembers().FirstOrDefault(mi => mi.MetadataToken == methodInfo.MetadataToken);
            List<string> result = new List<string>();

            //member.CustomAttributes.Select(att=>att.)

            return result;
        }
    }
}
