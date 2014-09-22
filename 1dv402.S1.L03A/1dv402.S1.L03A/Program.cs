using System;
using System.Linq;

namespace dv402.S1.L03A
{
	class MainClass
	{
		public static void Main (string[] args)

		{

			int numberOfsalaries=0;

			readInt("Ange antal löner att mata in: ", numberOfsalaries);


		}
		//method that returns user input, number of salaries, and handles input misstakes
		static int readInt(string prompt, int numberOfsalaries)
		{
			while (true) 
			{
				try 
				{
					Console.Write (prompt);
					numberOfsalaries = int.Parse (Console.ReadLine ());
					int[] salaries = new int[numberOfsalaries];

						if(numberOfsalaries < 2)
						{
							Console.BackgroundColor = ConsoleColor.Red;
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine ("För att kunna göra en beräkning måste antalet löner vara minst 2");

							Console.ResetColor ();

							//Gives user option to close program or start over	
							restartCalculation(numberOfsalaries);
						}
				
					int count=0;

					//asks for the right number of salary values user input wants and puts them in an array
					for (count = 0; count < salaries.Length; count++) 
					{
						Console.Write ("Mata in lön {0}: ", count+1);
						salaries[count] = Convert.ToInt32(Console.ReadLine());

						if(salaries[count] < 1) 
						{
							Console.BackgroundColor = ConsoleColor.Red;
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine ("Inmatad lön kan inte vara 0 kr eller mindre");
							Console.ResetColor ();

							//Gives user option to close program or start over
							restartCalculation(numberOfsalaries);
						}
					}

				processSalaries(numberOfsalaries, salaries);
				return numberOfsalaries;
				}

				catch (FormatException)
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("Antalet löner ska vara ett heltal och enbart skrivas med siffror");
					Console.ResetColor ();

				}
				catch (Exception) {//fattar inte varför negativa tal inte fastnar i if satsen ovan
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("Antalet löner kan inte vara negativt!");
					Console.ResetColor ();
				}
			}
		}


		//Method that processes entered values, makes calculations and displays those calculations
		static void processSalaries(int numberOfSalaries, int[] salaries){

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
			decimal salaryMedian=0;
			int size = copyOfArray.Length;
			int middle = size / 2;

			//handle if array lenght is even or uneven
			if(size % 2!= 0)
			{
				salaryMedian = (decimal)copyOfArray[middle];
				Convert.ToInt32(Math.Round(salaryMedian));
			}
			else
			{
				salaryMedian = ((decimal)copyOfArray[middle] + (decimal)copyOfArray[middle - 1]) / 2;
				Convert.ToInt32(Math.Round(salaryMedian));
			}


			//Print out calculations
			Console.WriteLine ("\n------------------------------------");
			Console.WriteLine ("{0,-16}{1,15:c0}", "Medianlön:", salaryMedian);
			Console.WriteLine ("{0,-16}{1,15:c0}", "Medellön:", salaryAverage);					
			Console.WriteLine ("{0,-16}{1,15:c0}", "Lönespridning:", salaryDifference);
			Console.WriteLine ("------------------------------------");


			//Loop through array and display input salaries in three columns
			foreach (int item in salaries){
				if (item % 3 == 2) 
				{
					Console.WriteLine ("{0, 10}", item);
				} 
				else 
				{
					Console.Write("{0, 10}", item);
				}
			}

	
			//Gives user option to close program or start over
			restartCalculation (numberOfSalaries);
		}

		static void restartCalculation(int numberOfSalaries)
		{
			Console.BackgroundColor = ConsoleColor.Green;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine ("\nTryck tangent för ny beräkning - Esc avslutar");
				
			if (Console.ReadKey(true).Key != ConsoleKey.Escape)
				{
				readInt ("Ange antal löner att mata in: ", numberOfSalaries);
				}
				else
				{
				return;
				}
		}
	}
}
  