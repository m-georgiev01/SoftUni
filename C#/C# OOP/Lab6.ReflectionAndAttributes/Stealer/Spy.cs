using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            Type classType = typeof(Hacker);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                     BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new();
            sb.AppendLine($"Class under investigation: {className}");

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            foreach (var field in classFields.Where(cf => requestedFields.Contains(cf.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] publicFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new();

            foreach (FieldInfo field in publicFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var privateMethod in privateMethods.Where(pm => pm.Name.StartsWith("get")))
            {
                sb.AppendLine($"{privateMethod.Name} have to be public!");
            }

            foreach (var publicMethod in publicMethods.Where(pm => pm.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }

 
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new();

            foreach (var classMethod in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{classMethod.Name} will return {classMethod.ReturnType.FullName}");
            }

            foreach (var classMethod in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{classMethod.Name} will set field of {classMethod.GetParameters().First().ParameterType}");
            }


            return sb.ToString().Trim();
        }
    }
}
