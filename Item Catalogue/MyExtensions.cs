using System;
using System.Collections.Generic;
using System.Text;

// for reference -> https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        //simple extension to remove spaces from a string
        public static string removeSpaces(this String str)
        {
            return str.Replace(" ", "");
        }
    }
}
