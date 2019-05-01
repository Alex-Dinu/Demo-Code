using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// To implement Dependency Injection, which is the poor-man's fix for the Dependency Inversion Principle, we need to implement the Explicit Dependency Principle
    /// which asks us to send in all the references in the constructor.
    /// .NET Core implements IoC (Inversion of Control) container
    /// </summary>
    class DependencyInjectionPrincipleEnd
    {
        private IDoSomething4 _doSomething4;

        public DependencyInjectionPrincipleEnd(IDoSomething4 obj)
        {
            _doSomething4 = obj;
        }
        public void PerformATask()
        {
            _doSomething4.DoIt();

        }

    }

    public interface IDoSomething4
    {
        void DoIt();
    }

    public class DoSomething4 : IDoSomething4
    {
        public void DoIt()
        {
            Console.WriteLine("I did it");
        }
    }
}
