using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BreakFastTasks;

namespace CoreCollectionsAsync
{

    class SimpleBreakfast
    {
        public static DateTime startTime;

        public static void BreakFastDemo_2()
        {
            Task omletteTask = MakeOmletteAsync();
            Task toastTask = MaketoastAsync();
            Task.WaitAll(omletteTask, toastTask);
            Console.WriteLine("Breakfast is ready!");
        }

        public static async Task MakeOmletteAsync()
        {
            DateTime start = DateTime.Now;

            //Prepare Omlette
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the Omlette at {startTime.ToString()}");
            Omlette myOmlette = new Omlette("myOmlette");
            myOmlette.OnProgress += Progress;
            await Task.Run(myOmlette.Start);
            Console.WriteLine("Finish Omlette");
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;
            Console.WriteLine($"Omlette is ready at {end.ToString()}");
            Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");
        }

        //-----------------------------------------------------------

        public static async Task MaketoastAsync()
        {
            DateTime start = DateTime.Now;

            //Prepare Toast
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the Toast at {startTime.ToString()}");
            Omlette myToast = new Omlette("myToast");
            myToast.OnProgress += Progress;
            await Task.Run(myToast.Start);
            Console.WriteLine("Finish Toast");
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;
            Console.WriteLine($"Toast is ready at {end.ToString()}");
            Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");
        }

        //-----------------------------------------------------------

        //public void MakeSalad()

        public static void MakeBreakfastDemo_1()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            DateTime start = DateTime.Now;

            //Prepare Omlette
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the Omlette at {startTime.ToString()}");
            Omlette myOmlette = new Omlette("myOmlette");
            myOmlette.OnProgress += Progress;

            myOmlette.Start();

            //-------------------------------------------------------
            //Prepare toast
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the toast at {startTime.ToString()}");
            Toast toast = new Toast("toast");
            toast.OnProgress += Progress;

            toast.Start();

            //-------------------------------------------------------
            //Prepare first cucumbers
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the first cucumber at {startTime.ToString()}");
            Cucumber cucumber1 = new Cucumber("first cucumber");
            cucumber1.OnProgress += Progress;

            cucumber1.Start();

            //-------------------------------------------------------
            //Prepare second cucumbers
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the second cucumber at {startTime.ToString()}");
            Cucumber cucumber2 = new Cucumber("second cucumber");
            cucumber2.OnProgress += Progress;

            cucumber2.Start();

            //-------------------------------------------------------
            //Prepare tomato
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the tomato at {startTime.ToString()}");
            Tomato tomato = new Tomato("tomato");
            tomato.OnProgress += Progress;

            Console.WriteLine();
            
            tomato.Start();

            stopWatch.Stop();
            Console.WriteLine($"Breakfast is ready after {stopWatch.Elapsed.TotalSeconds} seconds");
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;
            Console.WriteLine($"Breakfast is ready at {end.ToString()}");
            Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");

        }

        //The event OnProgressUpdate will fire this function! 
        static void Progress(object? sender, int percent)
        {
            if (sender is TaskExecutor)
            {

                TaskExecutor obj = (TaskExecutor)sender;
                Console.WriteLine($"Progress for {obj.Name}: {percent}%");
            }
        }

        //The event OnFinish will fire this function! 
        static void Finish(object? sender, EventArgs e)
        {
            if (sender is TaskExecutor)
            {
                TaskExecutor obj = (TaskExecutor)sender;
                Console.WriteLine($"\n{obj.Name} is ready!");
            }
        }
    }
}
