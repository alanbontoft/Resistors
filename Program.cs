using System;

using Resistors;

namespace core3console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var res = new PreferredResistors();

            // res.Range = ResistorRange.E48;

            // res.Range = ResistorRange.E24;

            var d = res.nearest(1.01);


        }
    }
}
