using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// Overriding virtual methods is another option to implement Open Closed Principle.
    /// </summary>
    class OpenClosedPrincipleEndOption2
    {
        public void DoOneThingAction()
        {
            new DoOneThingOption2Base().LogStart();

            new DoOneThingOption2Derived().LogStart();

        }
    }





    public class DoOneThingOption2Base
    {
        public virtual void LogStart()
        {
            Console.WriteLine("Goodby");
        }
    }

    public class DoOneThingOption2Derived : DoOneThingOption2Base
    {
        public override void LogStart()
        {
            Console.WriteLine("Hello");
        }
    }


}