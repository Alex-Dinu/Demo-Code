using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NetCoreAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
             new Sync.Breakfast().PrepareBreakfast();
               
             //await new Async.Breakfast().PrepareBreakfast();

             //await new Async.Breakfast().PrepareBreakfast2();

             //await new Async.Breakfast().PrepareBreakfast3();

            Console.ReadLine();
        }
    }
}
