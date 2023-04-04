using System;
namespace async_test
{
	public class Egg
	{
		public int? id { get; set; }

        public string? name { get; set; }

        // The average inner temperature of the egg
        public decimal egg_temperature { get; set; }

        // Number of seconds the egg has been in boiling water
        public int egg_time { get; set; }

        // The temperature at which the egg is considered to be done
        public int done_temperature { get; set; }

        public decimal RemainingTime()
        {
            // X = (Y - 20) * 1.33
            // Y = done_temperature
            return ((done_temperature - 20) * 10) - egg_time;
        }
    }
}

