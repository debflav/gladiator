using System;
using Equipments;

namespace Gladiator
{
	public static class Alert
	{

		public static void initConsole(){
			Console.Title = "Gladiator";
		}
		public static void showAlert (string message)
		{
			Console.WriteLine(message);
		}

		public static void showAlertWith(string msg1, string ms2){
		
			Console.WriteLine(msg1 + " => " + ms2);

		}

		public static void showRedAlert (string message){
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message + "\n");
			Console.ResetColor();
		}
		public static void showyellowAlert (string message){
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message + "\n");
			Console.ResetColor();
		}

		/**
		 * Retourne un string pour visualiser le gladiator
		 *
		 * @return	string	
		 */
		public static void showGladiator(Gladiator p_gladiator){

			int nbResteOfPointEquipement = p_gladiator.NB_MAX_EQUIPMENT - p_gladiator.NbEquipmentCurent;

			string msg = "\n+++++++++++++++++++++++++++++++++++++++++\n\n";
			msg += "\tGladiateur : " + p_gladiator.GladiatorName + "\n";
			msg += "\t-----------------------\n";
			msg += "\tEquipement : \n";
			msg += "\tNombre point equipement restant : " + nbResteOfPointEquipement.ToString()  +"\n";
			foreach (Equipment oneEquipment in p_gladiator.Equipments) {
				msg += "\t - " + oneEquipment.Name + "\n";
			}
			msg += "\t-----------------------\n";
			msg += "\tNombe de defaite : " + p_gladiator.GladiatorDefeatNumber.ToString () + "\n";
			msg += "\tNombe de victoir : " + p_gladiator.GladiatorWinNumber.ToString () + "\n";
			msg += "\tPrioritée : " + p_gladiator.Priority.ToString() + "\n";
			msg += "\tIn game : " + p_gladiator.InGame.ToString () + "\n";
			msg += "\tNombre points de defence (nombres d'armes) : " + p_gladiator.NbPointDefence.ToString () + "\n";
			msg += "\n+++++++++++++++++++++++++++++++++++++++++\n";

			Console.WriteLine( msg );

		}

	}
}

