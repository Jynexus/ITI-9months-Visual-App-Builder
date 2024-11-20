using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] ar = new int[5];
			int max;
			for (int i = 0; i < 5; i++)
			{
								Console.WriteLine ("Insert a positive number");
								ar[i] = int.Parse(Console.ReadLine());
			}
			max = ar[0];
			for (int i = 1; i < 5; i++)
			{
								if (ar[i] > max)
				{
					max = ar[i];
				}
			}
			Console.WriteLine ("The maximum number is: " + max);
			Console.ReadLine();
		}
	}
}
