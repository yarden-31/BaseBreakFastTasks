using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakFastTasks
{
    class TaskExecutor
    {
        // תכונות
        private string name;
        private int timeInMiliSec;

        //-----------------------------------------------------------

        // properties
        public string Name { get { return this.name; } }

        //-----------------------------------------------------------

        public event EventHandler<int> OnProgress;

        //-----------------------------------------------------------

        //בנאי
        public TaskExecutor(string name, int ms)
        {
            this.timeInMiliSec = ms;
            this.name = name;
        }

        //-----------------------------------------------------------

        //מחקה זמן ביצוע פעולה
        public void Start()
        {
            for (int i = 1; i <= 10; i++)
            {
                
                Thread.Sleep(this.timeInMiliSec / 10);
                if (OnProgress != null)
                {
                    OnProgress(this, i * 10);
                }

            }
           
        }
    }

    //---------------------------------------------------------------

    class Omlette : TaskExecutor
    {
        public Omlette(string name) : base(name, 7000)
        {

        }
    }

    //---------------------------------------------------------------

    class Cucumber : TaskExecutor
    {
        public Cucumber(string name) : base(name, 5000)
        { }
    }

    //---------------------------------------------------------------

    class Tomato : TaskExecutor
    {
        public Tomato(string name) : base(name, 1000)
        { }
    }

    //---------------------------------------------------------------

    class Toast : TaskExecutor
    {
        public Toast(string name) : base(name, 6000)
        {

        }
    }

}

