using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleServiceTemplate
{
    class Program
    {
        public static int RunInterval = 5000;   // default to 5 seconds

        static void Main(string[] args)
        {
            AcceptArgs();
            StartTimers();
            Wait();
        }

        /// <summary>
        /// Awaits input for process runtime, with validation
        /// </summary>
        private static void AcceptArgs()
        {
            Console.Write("Give interval between process run time (in ms, greater than 4999): ");
            string input = Console.ReadLine();
            Console.WriteLine();
            int value = RunInterval;
            if (input == null || input.Length < 0 || !int.TryParse(input, out value) || value < RunInterval)
            {
                Console.WriteLine("Input is not an integer greater than 4999.");
                AcceptArgs();
            }
            else
            {
                RunInterval = value;
            }
        }

        /// <summary>
        /// Creates a timer and runs whatever is in Run
        /// </summary>
        private static void StartTimers()
        {
            Console.WriteLine("Starting scanner.");
            Timer myTimer = new Timer();
            myTimer.Elapsed += Run;
            myTimer.Interval = RunInterval;
            myTimer.Enabled = true;
        }

        /// <summary>
        /// While console is up, you can press ESC to stop
        /// </summary>
        private static void Wait()
        {
            Console.WriteLine("Press ESC to stop.");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // do nothing
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Process logic goes here
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        private static void Run(object src, ElapsedEventArgs e)
        {
            Console.WriteLine("Process kickoff.");
        }
    }
}
