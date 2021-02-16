using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolutionReferences
{
    public static class JsonHelpers
    {
        /// <summary>
        /// Gets a nested property value in the form property1:property2:propertyn
        /// </summary>
        /// <param name="root"></param>
        /// <param name="propertyPath">property1:property2:propertyn</param>
        /// <param name="defaultValue"></param>
        /// <returns>property value as string, else <paramref name="defaultValue"/> or null</returns>
        public static string GetChainedPropertyValue(this JsonElement root, string propertyPath, string defaultValue = "")
        {
            try
            {
                JsonElement filteredElement = root;
                var pathElements = propertyPath.Split(":");
                foreach (var element in pathElements)
                {
                    filteredElement = filteredElement.GetProperty(element);
                }
                return filteredElement.ToString();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns the property value as a string, or null if not found
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetJsonEnumeratedValue(this JsonElement.ObjectEnumerator properties, string name)
        {
            var property = properties.SingleOrDefault(a => a.Name == name);
            return property.Value.ValueKind != JsonValueKind.Undefined ? property.Value.ToString() : null;
        }

    }
}
