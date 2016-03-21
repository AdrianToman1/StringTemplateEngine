using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTemplateEngine
{
    public static class StringExtensions
    {
        public static String Replace(this String s, String oldValue, String newValue, StringComparison comparisonType)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            if (oldValue == null)
            {
                throw new ArgumentNullException("oldValue");
            }
            if (oldValue.Equals(String.Empty))
            {
                throw new ArgumentException("String cannot be of zero length.", "oldValue");
            }

            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = s.IndexOf(oldValue, comparisonType);
            while (index != -1)
            {
                sb.Append(s.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = s.IndexOf(oldValue, index, comparisonType);
            }
            sb.Append(s.Substring(previousIndex));

            return sb.ToString();
        }
    }
}
