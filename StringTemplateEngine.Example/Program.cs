using System;

namespace StringTemplateEngine.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Old method");
            Console.WriteLine("----------");
            
            OldMethod();

            Console.WriteLine();


            Console.WriteLine("Basic String Template");
            Console.WriteLine("---------------------");

            Basic();

            Console.WriteLine();

            Console.WriteLine("Pres any key to close.");
            Console.Read();
        }

        static void OldMethod()
        {
            String s = "hello <data>";
            s = s.Replace("<data>", "world");

            Console.WriteLine(s);
        }

        static void Basic()
        {
            StringTemplate stringTemplate = new StringTemplate("hello <data>");
            stringTemplate.Add("data", "world");

            Console.WriteLine(stringTemplate.Render());
        }

    }
}
