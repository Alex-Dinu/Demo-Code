using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    public class OpenClosedPrincipleStart
    {
        public void DoOneThingAction()
        {
            new DoOneThing().LogStart();
        }
    }

    public class DoOneThing
    {
        public void LogStart()
        {
            Console.WriteLine("Starting....");
        }
    }


}
