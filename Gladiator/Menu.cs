using System;

namespace Gladiator
{
	public class Menu
	{

		public void Show()
		{
			Console.WriteLine ("Choisissez une action: ");
			Console.WriteLine ("1 - Action1 ");
			Console.WriteLine ("2 - Action2 ");
			Console.WriteLine ("3 - Action3 ");
			ConsoleKeyInfo myAction = Console.ReadKey ();

		}

		/**
		 * Création d'un nouveau joueur
		 */
		public void newPlayer()
		{
			Console.WriteLine ("Vous devez créer un joueur pour commencer.");
			// Nom du joueur
			Console.WriteLine ("Entrer votre nom:");
			string lastname = Console.ReadLine ();

			// Prénom du joueur
			Console.WriteLine ("Entrer votre prenom:");
			string firstname = Console.ReadLine ();

			// Pseudo du joueur
			Console.WriteLine ("Entrer votre pseudo:");
			string pseudo = Console.ReadLine ();

			// Date courante
			DateTime currentTime = DateTime.Now;

			Player player1 = new Player (lastname, firstname, pseudo, currentTime);
			Console.WriteLine ("Joueur " + player1.Pseudo + " crée avec succès");
		}
	}
}

