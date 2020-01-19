using System;

namespace ScratchString
{
    public static class StringExtension
    {
        public static string GetValue(this string haystack, string sectionName, string separator = "=", string delimiter = ";", string defaultReturnValue = "")
        {
            if (string.IsNullOrEmpty(sectionName)) throw new ArgumentNullException(nameof(sectionName));
            if (string.IsNullOrEmpty(haystack)) throw new ArgumentNullException(nameof(haystack));
            if (string.IsNullOrEmpty(delimiter)) throw new ArgumentNullException(nameof(delimiter));

            var indexofSection = haystack.IndexOf(sectionName);

            if (indexofSection < 0) return defaultReturnValue;

            //get the next instance of the delimiter
            var indexofDelimiter = haystack.IndexOf(delimiter, indexofSection);

            //if the delimiter was not found, then this means that we should check to the end of the string, so set the 
            //index to the length of the haystack
            if (indexofDelimiter < 0)
            {
                indexofDelimiter = haystack.Length;
            }

            //Note: The below can be shortened, but for legibility I left it as multiple lines

            //get the value
            var value = haystack.Substring(indexofSection, (indexofDelimiter - indexofSection));

            //remove the section name, and trim
            value = value.Substring(sectionName.Length).Trim();

            //remove the separator, and trim
            value = value.Substring(separator.Length).Trim();

            return value;
        }
    }
}
