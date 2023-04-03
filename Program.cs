using System;
namespace async_test
{
	public class Program
	{
        // Mostly swiped from https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
        static async Task Main(string[] args)
        {
            Console.WriteLine("Egg boiler 1.0 Press return key to begin");
            Console.ReadKey();

            // TODO: Koka fler ägg
            // TODO: Slumpmässigt ta upp ägg ur kastrullen

            // Skapa ett nytt äggobjekt, dvs instansiera Egg-klassen

            Egg firstEgg = new Egg
            {
                id = 1,
                name = "Easteregg",
                egg_temperature = 20.0M,
                egg_time = 0,
                done_temperature = 70
            };
            Egg secondEgg = new Egg
            {
                id = 2,
                name = "Bioegg",
                egg_temperature = 20.0M,
                egg_time = 0,
                done_temperature = 60
            };
            Egg thirdEgg = new Egg
            {
                id = 3,
                name = "Farmegg",
                egg_temperature = 20.0M,
                egg_time = 0,
                done_temperature = 50
            };

            var firstEggTask = BoilEgg(firstEgg);
            var secondEggTask = BoilEgg(secondEgg);
            var thirdEggTask = BoilEgg(thirdEgg);

            var eggTasks = new List<Task> { firstEggTask, secondEggTask, thirdEggTask };

            while (eggTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(eggTasks);
                if (finishedTask == firstEggTask)
                {
                    Console.WriteLine("first egg is ready");
                    Egg eggResult = firstEggTask.Result;
                    PrintEgg(eggResult);

                }
                else if (finishedTask == secondEggTask)
                {
                    Console.WriteLine("second egg is ready");
                    Egg eggResult = secondEggTask.Result;
                    PrintEgg(eggResult);
                }
                else if (finishedTask == thirdEggTask)
                {
                    Console.WriteLine("third egg is ready");
                    Egg eggResult = thirdEggTask.Result;
                    PrintEgg(eggResult);
                }
                await finishedTask;
                eggTasks.Remove(finishedTask);
            }
                //PrintEgg(myEgg); // start of sim

                int simulationTime = 0; // Amount of seconds simulation has been running

            //myEgg = await BoilEgg(myEgg);

            //PrintEgg(myEgg); // end of sim
            Console.WriteLine("Main Method End");

            // Huvudsimuleringen har en tråd samt
            // Varje Ägg-objekt ska köra i en egen tråd
        }
        public async static Task<Egg> BoilEgg(Egg egg)
        {
            int boilingTime = 10;
            while (true)
            { 
                await Wait(boilingTime);
                //Console.WriteLine("10 seconds of boiling has occured");
                // vad ska göras här och hur ska det göras?
                /*
                 * Uppdatera äggets temp
                 * Uppdatera tiden ägget kokat
                 * Äggets temperatur ökar med 1 grad per 10 sek
                 */
                egg.egg_temperature += (0.1M * boilingTime);
                egg.egg_time += boilingTime;

                /*
                 * Är ägget färdigkokt?
                 * Är ÄT => 70C ?
                 */

                if (egg.egg_temperature >= egg.done_temperature)
                {
                        // egg is done!
                        return egg;
                }
            }
        }

public async static void SomeMethod()
{
Console.WriteLine("Some Method Started......");
await Wait(5);
Console.WriteLine("Some Method End");
}
public async static Task Wait(int delay = 1)
{
await Task.Delay(TimeSpan.FromSeconds(delay / 10));
Console.Write($".");
}

public static void PrintEgg (Egg egg)
{
Console.WriteLine($"{egg.name} has an inner temperature of {egg.egg_temperature} and has been boiling for {egg.egg_time} seconds");
}

}

}

