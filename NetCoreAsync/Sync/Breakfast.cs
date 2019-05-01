using System;
using System.Threading.Tasks;
using NetCoreAsync.Models;

namespace NetCoreAsync.Sync
{
    public class Breakfast
    {
        public void PrepareBreakfast()
        {

            Coffee coffee = PourCoffee();


            Egg egg = FryEgg(2);

            Bacon bacon = FryBacon(3);

            Toast toast = ToastBread(2);

            ApplyButter(toast);
            ApplyJam(toast);

            Juice oj = PourOJ();


            Console.WriteLine("Breakfast is ready");

        }


        private Coffee PourCoffee()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Pouring coffee.");
            Console.WriteLine("Coffee is ready");
            Console.ForegroundColor = ConsoleColor.White;

            return new Coffee();
        }

        private Egg FryEgg(int howMany)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Warming the egg pan....");
            Task.Delay(1000).Wait();
            Console.WriteLine($"Cracking {howMany} eggs");
            Console.WriteLine("Cooking the eggs...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Putting eggs on plate");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Eggs are ready");
            return new Egg();
        }

        private Bacon FryBacon(int slices)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine($"Putting {slices} of bacon in the pan");
            Console.WriteLine("Cooking first side of bacon....");
            Task.Delay(4000).Wait();
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon....");
            Task.Delay(4000).Wait();
            Console.WriteLine("Putting bacon on plate");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bacon is ready");
            return new Bacon();

        }

        private Toast ToastBread(int slices)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting");
            Task.Delay(2000).Wait();
            Console.WriteLine("Remove toast from toaster");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Toast is ready");
            return new Toast();

        }

        private void ApplyButter(Toast toast)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Applying butter to toasts");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Toasts are buttered");
        }

        private void ApplyJam(Toast toast)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Applying jam to toasts");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Toasts are jammed");
        }

        private Juice PourOJ()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Pouring OJ.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("OJ is ready");
            return new Juice();
        }
    }
}
