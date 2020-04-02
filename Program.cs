using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumeRest2020
{
    class Program
    {
        private static void SayHi()
        {
            int milliseconds = 500;
            Thread.Sleep(milliseconds);
            Console.WriteLine("Er I main - HI");
        }
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Worker worker = new Worker();
            worker.Start();
            for (int i = 0; i < 30; i++)
            {

                SayHi();
            }
            Console.ReadLine();
            Console.ReadKey();

        }

    }
}
