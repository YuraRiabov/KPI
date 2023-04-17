using System.Xml.Linq;
using NetLab1.Infrastructure;
using NetLab2;

var fileName = "lab2_data.xml";
var xml = Serializer.Serialize(DataGenerator.Generate().Persons);
using (var sw = new StreamWriter(fileName))
{
    sw.Write(xml);
}

var document = XDocument.Parse(File.ReadAllText(fileName));
new IOManager(new PersonService(document)).Process();
