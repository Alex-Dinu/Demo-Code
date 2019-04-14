using System;
using System.Collections.Generic;
using System.Text;

namespace Test.IntegrationTests
{
    public abstract class TestsBase : IDisposable
    {
        protected TestsBase()
        {
            // Do "global" initialization here; Called before every test method.
        }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
        }
    }
}
