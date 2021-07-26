using System;
using static ScratchEvent.Counter;

namespace ScratchEvent
{
	class Program
	{
		static void Main(string[] args)
		{
			Counter c = new Counter(new Random().Next(10));
			c.ThresholdReached += c_ThresholdReached;
			c.TotalIncreased += c_TotalIncreased;
			c.TotalIncreased += c_TotalIncreased2;

			Console.WriteLine("press 'a' key to increase total");
			while (Console.ReadKey(true).KeyChar == 'a')
			{
				Console.WriteLine("adding one");
				c.Add(1);
			}
		}

		static void c_ThresholdReached(object sender, EventArgs e)
		{
			Console.WriteLine("The threshold was reached.");
			Environment.Exit(0);
		}

		static void c_TotalIncreased(object sender, TotalIncreasedEventArgs e)
		{
			Console.WriteLine($"{e.OrigValue} will be increased with {e.IncreasedBy}");
		}

		static void c_TotalIncreased2(object sender, TotalIncreasedEventArgs e)
		{
			Console.WriteLine($"Total was increased to {e.Total}");
		}
	}
}
