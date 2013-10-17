using System;

namespace Gladiator
{
	public static class Alert
	{

		public static void showAlert (string message)
		{
			Console.WriteLine(message);
		}

		public static void shawAlertWithTitle(string msg1, string ms2){
		
			Console.WriteLine(msg1 + " => " + ms2);

		}

	}
}

