using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;
using Animal_class;
class Program
{
    static void Main(string[] args)
    {
        XDocument xmlDocument = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("ClassDiagram"));
        Assembly ast = Assembly.GetAssembly(typeof(Animal));
        var typeswithcomment = ast.GetTypes().Where(p => p.GetCustomAttribute<CommentAttribute>() != null);
        foreach (var i in typeswithcomment) { 
            CommentAttribute cmt = i.GetCustomAttribute<CommentAttribute>();
            XElement class_elem = new XElement("Class", new XAttribute("Name", i.Name), new XElement("comment", cmt.comment));
            xmlDocument?.Root.Add(class_elem);
            var mth = i.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var member in mth)
            {
                string modificator = "";
                if (member.IsPublic) modificator += "public ";
                if (member.IsVirtual) modificator += "override ";
                XElement memberElement = new XElement("Method",
                    new XAttribute("Modifier", modificator),
                    new XAttribute("Call", member.Name),
                    new XAttribute("Type", member.MemberType.ToString()));

                class_elem.Add(memberElement);
            }
            var constructors = i.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var constructor in constructors)
            {
                XElement memberElement = new XElement("Constructor",
                    new XAttribute("Class", constructor.DeclaringType.Name),
                    new XAttribute("Type", "Constructor"));
                var parameters = constructor.GetParameters();
                foreach (var parameter in parameters)
                {
                    XElement parameterElement = new XElement("Parameter",
                        new XAttribute("Name", parameter.Name),
                        new XAttribute("Type", parameter.ParameterType.Name));

                    memberElement.Add(parameterElement);
                }
                class_elem.Add(memberElement);
            }

        }
        xmlDocument.Save("ClassDiagram.xml");
        Console.WriteLine("XML-представление диаграммы классов сохранено в файле ClassDiagram.xml");
    }
}


