using System;
using System.Linq;

namespace dv402.S1.L03A
{
	class MainClass
	{
		public static void Main (string[] args)

		{

			uint numberOfsalaries=0;

			//runs method that returns number of salaries to process
			ReadInt("Ange antal löner att mata in: ", numberOfsalaries);

		}


		//method that returns number of salaries, and handles input errors
		static uint ReadInt(string prompt, uint numberOfsalaries)
		{
			int[] salaries = new int[numberOfsalaries];
			int count=0;

			while (true) 
			{
				try 
				{
					Console.Write (prompt);
					numberOfsalaries = uint.Parse (Console.ReadLine ());
					salaries = new int[numberOfsalaries];

					if (numberOfsalaries < 2) 
					{
						throw new ArgumentException ();
					}

				} 
				catch (ArgumentException) 
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("För att kunna göra en beräkning måste antalet löner vara minst 2");

					Console.BackgroundColor = ConsoleColor.Green;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("\nTryck tangent för ny beräkning - Esc avslutar");
					Console.ResetColor ();

					if (Console.ReadKey (true).Key != ConsoleKey.Escape) 
					{
						ReadInt ("Ange antal löner att mata in: ", numberOfsalaries);
					} 
					else 
					{
						return (0);
					}
				} 
				catch (OverflowException) 
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");
					Console.ResetColor ();
				} 
				catch (FormatException) 
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");
					Console.ResetColor ();

				} catch (Exception) 
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("Okänt fel!");
					Console.ResetColor ();
				}
			

				while (true) 
				{
					try 
					{
						
						for (count = 0; count < salaries.Length; count++) 
						{
							Console.Write ("Mata in lön {0}: ", count + 1);
							salaries [count] = int.Parse (Console.ReadLine ());

							if (salaries [count] < 1) 
							{
								throw new ArgumentException ();
							}
						}
						//start processing values 
						ProcessSalaries (numberOfsalaries, salaries);
						return numberOfsalaries;

					} 
					catch (ArgumentException) 
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine ("Lönen måste vara ett tal större än 0");
						Console.ResetColor ();
					} 
					catch (OverflowException) 
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");
						Console.ResetColor ();
					} 
					catch (FormatException) 
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");
						Console.ResetColor ();

					} 
					catch (Exception) 
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine ("Okänt fel!");
						Console.ResetColor ();
					}
				}
			}
		}


		//Method that processes entered values, makes calculations and displays those calculations
		static void ProcessSalaries(uint numberOfSalaries, int[] salaries){

			//Calculate average salary
			double salaryAverage;
			salaryAverage = salaries.Average();

			//Calculate difference between highest/lowest salary copy array before sorting it.
			int salaryDifference;
			int[] copyOfArray = new int[numberOfSalaries];

			Array.Copy(salaries, copyOfArray, numberOfSalaries);
			Array.Sort(copyOfArray);
			salaryDifference = copyOfArray.Last() - copyOfArray[0];

			//Calculate median salary
			double salaryMedian=0;
			int size = copyOfArray.Length;
			int middle = size / 2;

			//handle if array lenght is even or uneven
			if(size % 2!= 0)
			{
				salaryMedian = (double)copyOfArray[middle];
				Convert.ToInt32(Math.Round(salaryMedian));
			}
			else
			{
				salaryMedian = ((double)copyOfArray[middle] + (double)copyOfArray[middle - 1]) / 2;
				Convert.ToInt32(Math.Round(salaryMedian));
			}


			//Print out calculations
			Console.WriteLine ("\n------------------------------------");
			Console.WriteLine ("{0,-16}{1,15:c0}", "Medianlön:", salaryMedian);
			Console.WriteLine ("{0,-16}{1,15:c0}", "Medellön:", salaryAverage);					
			Console.WriteLine ("{0,-16}{1,15:c0}", "Lönespridning:", salaryDifference);
			Console.WriteLine ("------------------------------------");

			int count = 0;

			//Loop through array and display input salaries in three columns
			for (count=0; count < salaries.Length; count++){
				if (count % 3 == 2) 
				{
					Console.WriteLine ("{0, 10}", salaries[count]);
				} 
				else 
				{
					Console.Write("{0, 10}", salaries[count]);
				}
			}

			//Gives user option to close program or start over
			Console.BackgroundColor = ConsoleColor.Green;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine ("\nTryck tangent för ny beräkning - Esc avslutar");
			Console.ResetColor ();

			if (Console.ReadKey(true).Key != ConsoleKey.Escape)
			{
				ReadInt ("Ange antal löner att mata in: ", numberOfSalaries);
			}
			else
			{
				return;
			}
		}
	}
}
