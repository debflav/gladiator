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
			//Menu menu = new Menu ();

			/* Création des joueurs */
			Player player1 = new Player ("Michel", "Jean", "JeanMich");
			Player player2 = new Player ("Toto", "Toto", "Toto");
			Player player3 = new Player ("Tata", "Tata", "Tata");
			Player player4 = new Player ("Tutu", "Tutu", "Tutu");

			Gladiator gladiator1 = new Gladiator ("Zorg");
			gladiator1.addEquipment (new Dagger());
			gladiator1.addEquipment (new LargeShield());

			Gladiator gladiator2 = new Gladiator ("molk");
			gladiator2.addEquipment (new Net ());
			gladiator2.addEquipment (new Helmet ());

			Gladiator gladiator3 = new Gladiator ("Blop");
			gladiator3.addEquipment (new Sword());
			gladiator3.addEquipment (new SmallShield());

			Gladiator gladiator4 = new Gladiator ("plup");
			gladiator4.addEquipment (new Dagger ());
			gladiator4.addEquipment (new Net ());

			Gladiator gladiator5 = new Gladiator ("blip");
			gladiator5.addEquipment (new Spear());
			gladiator5.addEquipment (new Helmet());

			Gladiator gladiator6 = new Gladiator ("Aey");
			gladiator6.addEquipment (new Trident ());
			gladiator6.addEquipment (new Net ());

			Gladiator gladiator7 = new Gladiator ("mechant");
			gladiator7.addEquipment (new Dagger());
			gladiator7.addEquipment (new LargeShield());

			Gladiator gladiator8 = new Gladiator ("gentil");
			gladiator8.addEquipment (new Sword ());
			gladiator8.addEquipment (new Helmet ());

			Gladiator gladiator9 = new Gladiator ("Captaine");
			gladiator9.addEquipment (new Dagger());
			gladiator9.addEquipment (new SmallShield());
			gladiator9.addEquipment (new Helmet());
			gladiator9.InGame = true;

			Gladiator gladiator10 = new Gladiator ("hulk");
			gladiator10.addEquipment (new Sword ());
			gladiator10.addEquipment (new Helmet ());
			gladiator10.InGame = true;

			/* Initialisation equipes */
			Team team1 = new Team ("Les cougars", "On est des dingues !!!", player1);
			Team team2 = new Team ("Les tigres", "Tigrou est notre ami", player1);
			Team team3 = new Team ("Panpan", "Cartouche !!!", player1);
			//Team team4 = new Team ("Grincheux", "Les septs nains", player1);
			//Team team5 = new Team ("La belle & la bete", "humpf", player1);
	
			Team team5 = new Team ("Angora", "On est des dingues !!!", player2);
			Team team6 = new Team ("Chaton", "Tigrou est notre ami", player2);
			Team team7 = new Team ("Poulette", "Cartouche !!!", player2);
			//Team team8 = new Team ("chiot", "Les septs nains", player2);
			//Team team9 = new Team ("tigrette", "humpf", player2);

			Team team10 = new Team ("satan", "On est des dingues !!!", player3);
			Team team11 = new Team ("mephistos", "Tigrou est notre ami", player3);
			Team team12 = new Team ("metalica", "Cartouche !!!", player3);
			//Team team13 = new Team ("666", "Les septs nains", player3);
			//Team team14 = new Team ("Shetan", "humpf", player3);

			Team team15 = new Team ("Mac", "On est des dingues !!!", player4);
			Team team16 = new Team ("Linux", "Tigrou est notre ami", player4);
			Team team17 = new Team ("PC", "Cartouche !!!", player4);
			//Team team18 = new Team ("IBM", "Les septs nains", player4);
			//Team team19 = new Team ("Amstrade", "humpf", player4);

			//player2.showTeam ();
			team1.WinNumber = 9;
			team1.MatchPlayed = 20;
			team2.WinNumber = 10;
			team2.MatchPlayed = 11;
			team3.WinNumber = 12;
			team3.MatchPlayed = 26;
			team5.WinNumber = 1;
			team5.MatchPlayed = 12;
			team6.WinNumber = 6;
			team6.MatchPlayed = 20;
			team7.WinNumber = 2;
			team7.MatchPlayed = 12;
			team10.WinNumber = 10;
			team10.MatchPlayed = 10;
			team11.WinNumber = 12;
			team11.MatchPlayed = 16;
			team12.WinNumber = 1;
			team12.MatchPlayed = 9;
			team15.WinNumber = 6;
			team15.MatchPlayed = 20;
			team16.WinNumber = 1;
			team16.MatchPlayed = 100;
			team17.WinNumber = 19;
			team17.MatchPlayed = 20;

			/* Add Gladiator to team */
			// Player 1
			team1.addGladiator (gladiator1);
			team1.addGladiator (gladiator2);
			team1.addGladiator (gladiator3);
			team2.addGladiator (gladiator4);
			team2.addGladiator (gladiator5);
			team2.addGladiator (gladiator6);
			team3.addGladiator (gladiator7);
			team3.addGladiator (gladiator8);
			team3.addGladiator (gladiator9);

			// Player 2
			team5.addGladiator (gladiator10);
			team5.addGladiator (gladiator1);
			team5.addGladiator (gladiator2);
			team6.addGladiator (gladiator3);
			team6.addGladiator (gladiator4);
			team6.addGladiator (gladiator5);
			team7.addGladiator (gladiator6);
			team7.addGladiator (gladiator7);
			team7.addGladiator (gladiator8);

			// Player 3
			team10.addGladiator (gladiator9);
			team10.addGladiator (gladiator10);
			team10.addGladiator (gladiator1);
			team11.addGladiator (gladiator2);
			team11.addGladiator (gladiator3);
			team11.addGladiator (gladiator4);
			team12.addGladiator (gladiator5);
			team12.addGladiator (gladiator6);
			team12.addGladiator (gladiator7);

			// Player 4
			team15.addGladiator (gladiator8);
			team15.addGladiator (gladiator9);
			team15.addGladiator (gladiator10);
			team16.addGladiator (gladiator1);
			team16.addGladiator (gladiator2);
			team16.addGladiator (gladiator3);
			team17.addGladiator (gladiator4);
			team17.addGladiator (gladiator5);
			team17.addGladiator (gladiator6);

			/*	Ajouter une team au combat */
//			Fight fight = new Fight ();
//			fight.addTeamToFight(team1);
//			fight.addTeamToFight(team5);
//			fight.addTeamToFight(team10);
//			fight.addTeamToFight(team17);
//			fight.initializeFight ();
			//fight.teamListShow ();

			// test Duel
			Duel d = new Duel (gladiator9, gladiator10);
			Gladiator winner = d.InTheArena ();

			if (winner == null) {
				Alert.showAlert ("les deux gladiateurs on perdu !...");
			} else {
				Alert.showGladiator (winner);
			}



		}
	}
}
