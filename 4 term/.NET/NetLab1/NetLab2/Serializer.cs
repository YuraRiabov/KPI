using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NetLab2;

public static class Serializer
{
    public static string Serialize<T>(T obj) where T: class
    {
        var serializer = new XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        using var xmlTextWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented};
        serializer.Serialize(xmlTextWriter, obj);
        return stringWriter.ToString();
    }

    public static T Deserialize<T>(this XElement element) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(element.CreateReader())!;
    }

    public static IEnumerable<T> Deserialize<T>(this IEnumerable<XElement> elements) where T : class
    {
        return elements.Select(Deserialize<T>);
    }
}