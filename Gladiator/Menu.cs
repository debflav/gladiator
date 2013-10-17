using System;

namespace Gladiator
{
	public class Menu
	{

		public void Show()
		{
			Console.WriteLine ("\n-----------------------");
			Console.WriteLine ("Choisissez une action:");
			Console.WriteLine ("1 - Ajouter une équipe.");
			Console.WriteLine ("2 - Ajouter un gladiateur.");
			Console.WriteLine ("3 - Ajouter un équipement à un gladiateur.");
			Console.WriteLine ("-----------------------");

			int myAction = Console.Read ();

			switch(myAction) {
			case 49: 
				this.addTeam ();
				break;
			case 50:
				Console.WriteLine ("Nom de l'équipe où ajouter le gladiateur à implementer...");

				this.addGladiatorInTeam ();
				break;
			case 51:
				break;
			default:
				Console.WriteLine ("Action non disponible");
				this.Show();
				break;
			}
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

		public void addTeam()
		{

			Team team1 = new Team ("Les cougars", "On est des dingues !!!");
			Console.WriteLine( "Créer: " + team1.TeamName);
			//Team team2 = new Team ("Les tigres", "Tigrou est notre ami");
			this.Show ();
		}

		public void addGladiatorInTeam ()
		{
			Gladiator gladiator1 = new Gladiator ("Boris");
			//team1.addGladiator (gladiator1);
		}
	}
}

