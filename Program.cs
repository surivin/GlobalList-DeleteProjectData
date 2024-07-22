using System.Xml;
using System.Linq;
using System.Xml.Linq;


var projectNames = new List<string>();
foreach (var projectName in File.ReadLines("projectNames.csv"))
{
    projectNames.Add(projectName.ToLower());
}

var projectsToDelete = new List<XElement>();
XDocument xmlDocument = XDocument.Load("XMLFile1.xml");

foreach (XElement el in xmlDocument.Root.Elements("GLOBALLIST"))
{
    foreach (var projectName in projectNames)
    {
        if (el.Attribute("name").Value.ToLower().Contains(projectName.ToLower()))
        {
            projectsToDelete.Add(el);
            Console.WriteLine(el.Attribute("name").Value);
        }
    }
}

foreach(XElement el in projectsToDelete)
{
    xmlDocument.Root.Elements("GLOBALLIST").Where(x => x.Attribute("name") == el.Attribute("name")).First().Remove();
}
xmlDocument.Save("XMLFile1.xml");
Console.WriteLine("");