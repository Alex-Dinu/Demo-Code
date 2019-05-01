using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// Here is a simple example where we break the DI principle. We instantiate a class inside the method,
    /// which tightly couples it with the class.
    /// </summary>
    class DependencyInjectionPrincipleStart
    {
        public void PerformATask()
        {
            DoSomething3 obj = new DoSomething3();
            obj.DoIt();

        }

    }

    public class DoSomething3
    {
        public void DoIt()
        {
            Console.WriteLine("I did it");
        }
    }
}
