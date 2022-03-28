using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        //async - method signature verifier (return - void/Task)
        //await

        public static  async void Algorithm()
        {
            //sync
            Console.WriteLine($"Sync Code ....{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            //Async- Api - Get Result
            string  result=await Task.Run<string>(() => {
                //Api- Communication
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Fetching Data From Api ....{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    System.Threading.Thread.Sleep(100);
                }
                return "Data From Api";
            
            });
            await Task.Run(() =>{ 
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Processing Data From Api .{result}...{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    System.Threading.Thread.Sleep(100);
                }
            });
            
            //Continue

        }

        static void Main()
        {
            //Algorithm();


            //PrepareBreakfast();
            PrepareBreakfastParallel();
            Console.Read();
        }
        

        private static async void PrepareBreakfast()
        {
            Coffee cup = await PourCoffeeAsync();
            Console.WriteLine($"coffee is ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine($"eggs are ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine($"bacon is ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine($"toast is ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static async void PrepareBreakfastParallel()
        {
            Task<Coffee> coffeeTask= PourCoffeeAsync();
            Task<Egg> eggsTask =  FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

          
          Coffee coffee=await coffeeTask;
            Console.WriteLine($"coffee is ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Egg eggs = await eggsTask;
            Console.WriteLine($"eggs are ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Bacon bacon = await baconTask;
            Console.WriteLine($"bacon is ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

           Toast toast= await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine($"toast is ready {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }
        private static Juice PourOJ()
        {
            Console.WriteLine($"Pouring orange juice....{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine($"Putting jam on the toast...{System.Threading.Thread.CurrentThread.ManagedThreadId}");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine($"Putting butter on the toast{System.Threading.Thread.CurrentThread.ManagedThreadId}");

        private static Task<Toast> ToastBreadAsync(int slices)
        {
            return Task.Run<Toast>(() =>{
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine($"Putting a slice of bread in the toaster...{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
                Console.WriteLine($"Start toasting...{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(3000).Wait();
                Console.WriteLine($"Remove toast from toaster {System.Threading.Thread.CurrentThread.ManagedThreadId}");

                return new Toast();
            });
            
        }

        private static Task<Bacon> FryBaconAsync(int slices)
        {
            return Task.Run<Bacon>(() => {
                Console.WriteLine($"putting {slices} slices of bacon in the pan {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine("cooking first side of bacon...");
                Task.Delay(3000).Wait();
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine("flipping a slice of bacon");
                }
                Console.WriteLine("cooking the second side of bacon...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Put bacon on plate");

                return new Bacon();
            });
            
        }

        private static Task<Egg> FryEggsAsync(int howMany)
        {
           return Task.Run<Egg>(() =>{
                Console.WriteLine("Warming the egg pan...");
                Task.Delay(3000).Wait();
                Console.WriteLine($"cracking {howMany} eggs");
                Console.WriteLine("cooking the eggs ...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Put eggs on plate");

                return new Egg();

            });
            
        }

        private static Task<Coffee> PourCoffeeAsync()
        {
            return  Task.Run<Coffee>(() =>
            {
                Console.WriteLine($"Pouring coffee ....{System.Threading.Thread.CurrentThread.ManagedThreadId}.");
                return new Coffee();
            });
        }
    }
}
    