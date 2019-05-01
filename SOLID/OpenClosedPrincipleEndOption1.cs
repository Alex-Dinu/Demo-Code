using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// Passing in a parameter that will determine the outcome is one way to implement the Open\Closed Principle.
    /// </summary>
    class OpenClosedPrincipleEndOption1
    {
            public void DoOneThingAction()
            {
                new DoOneThingOption1().LogStart("Starting");
            }
        }

        public class DoOneThingOption1
        {
            public void LogStart(string message)
            {
                Console.WriteLine(message);
            }
        }


    }