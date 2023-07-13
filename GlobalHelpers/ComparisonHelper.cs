using System.Reflection;

namespace GlobalHelpers;

public static class ComparisonHelper
{
    /// <summary>
    /// Compares two objects of the same type, allowing you to skip a list or array of properties.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    /// <param name="obj1">The first object to compare.</param>
    /// <param name="obj2">The second object to compare.</param>
    /// <param name="propertiesToSkip">An optional list of properties to skip during the comparison.</param>
    /// <returns>True if the objects are equal, false otherwise.</returns>
    public static bool CompareObjects<T>(T obj1, T obj2, IEnumerable<string>? propertiesToSkip = null)
    {
        try
        {
            // Check if both objects are null or the same instance
            if (ReferenceEquals(obj1, obj2))
                return true;

            // Check if either object is null
            if (obj1 == null || obj2 == null)
                return false;

            // Get the type of the objects
            Type type = typeof(T);

            // Get all properties of the type
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                // Skip properties that are in the propertiesToSkip list or DateTime properties
                if ((propertiesToSkip != null && propertiesToSkip.Contains(property.Name)) || property.PropertyType == typeof(DateTime))
                    continue;

                // Get the values of the properties for obj1 and obj2
                object? value1 = property.GetValue(obj1);
                object? value2 = property.GetValue(obj2);

                // If the values are null, continue to the next property
                if (ReferenceEquals(value1, value2))
                    continue;

                // Compare the values
                if (value1 == null || !value1.Equals(value2))
                    return false;
            }
            return true;
        }

        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            return false;
        }
    }

        
}
