using System;
using Equipments;
using Equipments.Attack;
using Equipments.Defend;
using Equipments.Interfaces;
using Equipments.DefendAndAtack;

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
			Player player3 = new Player ("Tata", "Tata", "Tata", date2);
			Player player4 = new Player ("Tutu", "Tutu", "Tutu", date2);


			Console.WriteLine(" ----------- TEST GLADIATOR ---------------- ");

			Gladiator monGlatiateur = new Gladiator ("Bim");
			monGlatiateur.GladiatorWinNumber = 5;
			monGlatiateur.GladiatorDefeatNumber = 5;

			Console.WriteLine ("% victoir = " + monGlatiateur.getPercentVictory ());
			Console.WriteLine (" NbEquipmentCurent " + monGlatiateur.NbEquipmentCurent);

			monGlatiateur.addEquipment (maDague);
			monGlatiateur.addEquipment (monEpee);

			Console.WriteLine (" NbEquipmentCurent " + monGlatiateur.NbEquipmentCurent);

			Console.WriteLine (" NbEquipmentCurent " + monGlatiateur.NbEquipmentCurent);
			//Console.WriteLine (" ->  " + monGlatiateur.attack().ToString());


			/* Initialisation equipes */
			Team team1 = new Team ("Les cougars", "On est des dingues !!!", player1);
			Team team2 = new Team ("Les tigres", "Tigrou est notre ami", player1);
			Team team3 = new Team ("Panpan", "Cartouche !!!", player3);
			Team team4 = new Team ("Grincheux", "Les septs nains", player2);
			Team team5 = new Team ("La belle & la bete", "humpf", player4);

			/*	Ajouter une equipe à un joueur */
			Console.WriteLine( "-----------Add Team------------");
			if (!player1.addTeam (team1))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
				team1.WinNumber = 9;
				team1.MatchPlayed = 12;
			if (!player1.addTeam (team2))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
				team2.WinNumber = 10;
				team2.MatchPlayed = 10;
			if (!player3.addTeam (team3))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
				team3.WinNumber = 12;
				team3.MatchPlayed = 26;
			if (!player2.addTeam (team4))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
				team4.WinNumber = 1;
				team4.MatchPlayed = 10;
			if (!player4.addTeam (team5))
				Console.WriteLine ( "Limite du nombre d'équipe fixé à cinq");
				team5.WinNumber = 6;
				team5.MatchPlayed = 20;
			player1.showTeam ();
			Console.WriteLine( "-------------------------------");

			/*	Ajouter un gladiateur dans une équipe */
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

			Console.WriteLine( "---------------------------");
			Console.WriteLine( "Combat");
			Console.WriteLine( "---------------------------");

			Gladiator oneGladiateur = new Gladiator ("Zorg");
			oneGladiateur.addEquipment (new Dagger());
			oneGladiateur.addEquipment (new LargeShield());
			oneGladiateur.InGame = true;
			Alert.showGladiator (oneGladiateur);

			Gladiator twoGladiateur = new Gladiator ("molk");
			twoGladiateur.addEquipment (new Dagger ());
			twoGladiateur.addEquipment (new SmallShield ());
			twoGladiateur.InGame = true;
			Alert.showGladiator (twoGladiateur);

			Duel d = new Duel (oneGladiateur, twoGladiateur);

			Gladiator winner = d.InTheArena ();
			Alert.showGladiator (winner);
		

			/*	Ajouter une team au combat */
			Console.WriteLine( "-----------Add Team------------");
			Fight fight = new Fight ();
			fight.addTeamToFight(team1);
			fight.addTeamToFight(team2);
			fight.addTeamToFight(team3);
			fight.addTeamToFight(team4);
			fight.addTeamToFight(team5);
			fight.initializeFight ();
			//fight.teamListShow ();
			Console.WriteLine( "-------------------------------");

		}
	}
}
