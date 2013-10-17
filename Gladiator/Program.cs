using System;
using Equipments;
using Equipments.Attack;
using Equipments.Defend;
using Equipments.Interfaces;

namespace Gladiator
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			/* Menu */
			Menu menu = new Menu ();
			//menu.newPlayer ();
			//menu.Show ();



			Dagger maDague = new Dagger();
			Net MonFilet = new Net();
			Spear MaLance = new Spear ();
			Sword monEpee = new Sword ();
			Helmet monCasque = new Helmet ();
			Console.WriteLine (monCasque.Name);
			Console.WriteLine (MonFilet.Name);
			Console.WriteLine (MaLance.Name);
			Console.WriteLine (monEpee.Name);

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

			Console.WriteLine(" ----------- TEST GLADIATOR ---------------- ");

			Gladiator monGlatiateur = new Gladiator ("Bim");
			monGlatiateur.GladiatorWinNumber = 5;
			monGlatiateur.GladiatorLostNumber = 5;

			Console.WriteLine ("% victoir = " + monGlatiateur.getPercentVictoy ());
			Console.WriteLine (" NbEquipmentCurent " + monGlatiateur.NbEquipmentCurent);

			monGlatiateur.addEquipment (maDague);

			Console.WriteLine (" NbEquipmentCurent " + monGlatiateur.NbEquipmentCurent);

			monGlatiateur.addEquipment (MonFilet);
			monGlatiateur.addEquipment (MonFilet);
			monGlatiateur.addEquipment (MonFilet);
			monGlatiateur.addEquipment (MonFilet);
			monGlatiateur.addEquipment (MonFilet);

			Console.WriteLine (" NbEquipmentCurent " + monGlatiateur.NbEquipmentCurent);

			/*	*/
			Console.WriteLine( "-----------Add Team------------");
			if (!player1.addTeam (team1))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
			if (!player1.addTeam (team2))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
			player1.showTeam ();
			Console.WriteLine( "-------------------------------");

			/*	*/
			Console.WriteLine( "-------Add Gladiator-------");
			Gladiator gladiator1 = new Gladiator ("Boris");
			if(!team1.addGladiator (gladiator1))
				Console.WriteLine ("Vérifiez que l'équipe ne comporte pas déjà trois" +
				"joueurs ou que ce nom de gladiateur n'existe pas déjà dans cette équipe");
			team1.showGladiatorsFromTeam();
			team2.showGladiatorsFromTeam();
			team1.deleteGladiatorFromTeam (gladiator1);
			team1.showGladiatorsFromTeam();
			Console.WriteLine( "---------------------------");
		}
	}
}
