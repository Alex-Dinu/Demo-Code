using System;
using System.Threading.Tasks;
using NetCoreAsync.Models;

namespace NetCoreAsync.Async
{
    public class Breakfast
    {
        public async Task PrepareBreakfast()
        {

            Coffee coffee = PourCoffee();


            Egg egg = await FryEggAsync(2);

            Bacon bacon = await FryBaconAsync(3);

            Toast toast = await ToastBreadAsync(2);

            ApplyButter(toast);
            ApplyJam(toast);

            Juice oj = PourOJ();

            Console.WriteLine("Breakfast is ready");

            Console.ReadLine();
        }

        public async Task PrepareBreakfast2()
        {

            Coffee coffee = PourCoffee();


            Task<Egg> eggTask = FryEggAsync(2);

            Task<Bacon> baconTask = FryBaconAsync(3);

            Task<Toast> toastTask = ToastBreadAsync(2);

            // Before applying butter and jam, we have to take it out of the toaster....
            var toast = await toastTask;

            ApplyButter(toast);
            ApplyJam(toast);

            Juice oj = PourOJ();


            // Before breakfast is ready, all tasks need to be finished.
            // All tasks are running asynchronously, until they are all completed.
            await Task.WhenAll(eggTask, baconTask, toastTask);

            Console.WriteLine("Breakfast is ready");

            Console.ReadLine();
        }

        public async Task PrepareBreakfast3()
        {

            Coffee coffee = PourCoffee();


            Task<Egg> eggTask = FryEggAsync(2);

            Task<Bacon> baconTask = FryBaconAsync(3);

            Task<Toast> toastTask = ToastBreadAsync(2);
            toastTask = ToastWithButterAndJam(toastTask);

            async Task<Toast> ToastWithButterAndJam(Task<Toast> breadToasting)
            {
                var toast = await breadToasting;

                ApplyButter(toast);
                ApplyJam(toast);
                return toast;
            }

            Juice oj = PourOJ();


            // Before breakfast is ready, all tasks need to be finished.
            // All tasks are running asynchronously, until they are all completed.
            await Task.WhenAll(eggTask, baconTask, toastTask);


            Console.WriteLine("Breakfast is ready");

            Console.ReadLine();
        }


        #region Actions
        private Coffee PourCoffee()
        {

            Console.WriteLine("Pouring coffee.");
            Console.WriteLine("Coffee is ready");

            return new Coffee();

        }

        private async Task<Egg> FryEggAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan....");
            await Task.Delay(1000);
            Console.WriteLine($"Cracking {howMany} eggs");
            Console.WriteLine("Cooking the eggs...");
            await Task.Delay(3000);
            Console.WriteLine("Putting eggs on plate");
            Console.WriteLine("Eggs are ready");
            return new Egg();
        }

        private async Task<Bacon> FryBaconAsync(int slices)
        {

            Console.WriteLine($"Putting {slices} of bacon in the pan");
            Console.WriteLine("Cooking first side of bacon....");
            await Task.Delay(4000);
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon....");
            await Task.Delay(4000);
            Console.WriteLine("Putting bacon on plate");

             Console.WriteLine("Bacon is ready");
           return new Bacon();

        }

        private async Task<Toast> ToastBreadAsync(int slices)
        {

            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting");
            await Task.Delay(2000);
            Console.WriteLine("Remove toast from toaster");
              Console.WriteLine("Toasts are ready");
          return new Toast();

        }

        private void ApplyButter(Toast toast)
        {
            Console.WriteLine("Applying butter to toasts");
             Console.WriteLine("Toasts are buttered.");
       }

        private void ApplyJam(Toast toast)
        {
            Console.WriteLine("Applying jam to toasts");

            Console.WriteLine("Toasts are jammed.");
        }

        private Juice PourOJ()
        {

            Console.WriteLine("Pouring OJ.");

            Console.WriteLine("OJ is ready");
            return new Juice();
        } 
        #endregion



    }
}
