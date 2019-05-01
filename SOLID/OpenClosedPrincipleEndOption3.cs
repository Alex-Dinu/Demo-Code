using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// Using factories, we can determine which concrete option we want and use it.
    /// We can also use interfaces instead of abstract classes.
    /// We could also replace the if statement with reflection to determine the concrete class we want to return.
    /// We could also use Dependency Injection to pass in the concrete class to be used.
    /// </summary>
    class OpenClosedPrincipleEndOption3
    {
        public void DoOneThingAction()
        {
            var factory = new Factory();

            var doer = factory.Create(1);

            doer.DoSomething();
        }

    }


    public class Factory
    {
        public DoOneThingOption3 Create(int option)
        {
            if (option == 1)
                return new DoOneThingOption3a();

            return new DoOneThingOption3b();
        }
    }
    public abstract class DoOneThingOption3
    {
        public abstract void DoSomething();
    }
    public class DoOneThingOption3a: DoOneThingOption3
    {
        public override void DoSomething()
        {
            Console.WriteLine("option 3a");
        }
    }

    public class DoOneThingOption3b: DoOneThingOption3
    {
        public override void DoSomething()
        {
            Console.WriteLine("option 3b");
        }
    }
}
