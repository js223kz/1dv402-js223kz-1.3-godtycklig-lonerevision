using System;
using System.Linq;
namespace dv402.S1.L03A
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			int numberOfSalaries = 0;


			do {
				numberOfSalaries = ReadInt ("Ange antal löner att mata in: ");
				
				//check that number of salaries are 2 or more
				try {
					if (numberOfSalaries < 2) {
				
						throw new ArgumentException ();
					}
				
					ProcessSalaries (numberOfSalaries);
				
				} catch (ArgumentException) {
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("För att kunna göra en beräkning måste antalet löner vara minst 2");
				
				}
					
				//Gives user option to close program or start over when calculation is finished
				Console.BackgroundColor = ConsoleColor.Green;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine ("\nTryck tangent för ny beräkning - Esc avslutar");
				Console.ResetColor ();

			} while (Console.ReadKey (true).Key != ConsoleKey.Escape);
		}
	
		//method that returns userinput as an int
		static int ReadInt(string prompt)
		{
			int userInput = 0;
			while (true)
			{
				try
				{
					Console.Write (prompt);
					userInput = int.Parse (Console.ReadLine ());

					return userInput;

				} catch (ArgumentException) {
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");	
				}
				catch (OverflowException){
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");
					Console.ResetColor ();
				}
				catch (FormatException){
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("FEL! Kan inte tolkas som en giltig summa");
					Console.ResetColor ();
				} 
				catch (Exception){
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine ("Okänt fel!");
					Console.ResetColor ();
				}
			}
		}

		//method that processes values of each salarie
		static void ProcessSalaries(int numberOfSalaries){

			int count = 0;
			int[] salaries = new int[numberOfSalaries];
			int valueOfSalaries = 0;

			for (count = 0; count < numberOfSalaries; count++){
				valueOfSalaries = ReadInt ("Mata in lön " + (count + 1) + " : ");
				salaries [count] = valueOfSalaries;
			}
				
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
			if(size % 2!= 0){

				salaryMedian = (double)copyOfArray[middle];
				Convert.ToInt32(Math.Round(salaryMedian));
			}else{

				salaryMedian = ((double)copyOfArray[middle] + (double)copyOfArray[middle - 1]) / 2;
				Convert.ToInt32(Math.Round(salaryMedian));
			}

			//Print out calculations
			Console.WriteLine ("\n------------------------------------");
			Console.WriteLine ("{0,-16}{1,15:c0}", "Medianlön:", salaryMedian);
			Console.WriteLine ("{0,-16}{1,15:c0}", "Medellön:", salaryAverage);	
			Console.WriteLine ("{0,-16}{1,15:c0}", "Lönespridning:", salaryDifference);
			Console.WriteLine ("------------------------------------");

			int i = 0;
			//Loop through array and display input salaries in three columns
			for (i=0; i < salaries.Length; i++){
				if (i % 3 == 2){

					Console.WriteLine ("{0, 10}", salaries[i]);
				}else{

					Console.Write("{0, 10}", salaries[i]);
				}
			}
		}
	}
}
