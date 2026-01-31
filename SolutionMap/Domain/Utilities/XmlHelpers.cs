using System.Xml;

namespace SolutionMap.Domain.Utilities;

public static class XmlHelpers
{
    public static string? GetXmlPropertyValue(this XmlElement rootElement, string name, string defaultValue = null)
    {
        var elements = rootElement.GetElementsByTagName(name);
        return (elements.Count > 0) ? elements[0]?.InnerText : defaultValue;
    }

}
