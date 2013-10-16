using System;
using System.Collections.Generic;

namespace Gladiator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/* Initialisation Joueurs */
			DateTime date1 = new DateTime(2010, 1, 18);
			DateTime date2 = new DateTime(2010, 5, 16);

			Player player1 = new Player ("Michel", "Jean", "JeanMich", date1);
			Player player2 = new Player ("Toto", "Toto", "Toto", date2);

			//Console.WriteLine (player1.Pseudo);
			//Console.WriteLine (player2.Lastname);

			/* Initialisation equipes */
			Team team1 = new Team ("Les cougars", "On est des dingues !!!");
			Team team2 = new Team ("Les tigres", "Tigrou est notre ami");
			player1.ajouterEquipe (team1);
			player1.ajouterEquipe (team2);

		}
	}
}
