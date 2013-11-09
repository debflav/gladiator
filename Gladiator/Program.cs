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

			Alert.initConsole ();


			/*
			 * +--------------------------+
			 * |	Jeu de test			  |
			 * +--------------------------+
			/* 

			//Création des joueurs */
			Player player1 = new Player ("Michel", "Jean", "JeanMich");
			Player player2 = new Player ("Philipe", "Philipe", "Philipe");
			Player player3 = new Player ("Maltilde", "Maltilde", "Maltilde");
			Player player4 = new Player ("Herber", "Herber", "Herber");
			Player player5 = new Player ("Marc", "Marc", "Marc");
			Player player6 = new Player ("Julie", "Julie", "Julie");

			//-------------------------
			// Team 1 //////////
			Team team1 = new Team ("Les Molks", "On est des dingues !!!", player1);
			team1.WinNumber = 9;
			team1.MatchPlayed = 20;

			// Team 1 : Gladiateur ////////
			Gladiator gladiator1 = new Gladiator ("Molki");
			gladiator1.addEquipment (new Dagger());
			gladiator1.addEquipment (new LargeShield());
			gladiator1.Priority = 1;

			Gladiator gladiator2 = new Gladiator ("Molka");
			gladiator2.addEquipment (new Net ());
			gladiator2.addEquipment (new Helmet ());
			gladiator1.Priority = 2;

			Gladiator gladiator3 = new Gladiator ("Molko");
			gladiator3.addEquipment (new Sword());
			gladiator3.addEquipment (new SmallShield());
			gladiator1.Priority = 3;

			team1.addGladiator (gladiator1);
			team1.addGladiator (gladiator2);
			team1.addGladiator (gladiator3);

			//-------------------------
			// Team 2 /////////
			Team team2 = new Team ("Les Bisounours", "Tigrou est notre ami", player2);
			team2.WinNumber = 10;
			team2.MatchPlayed = 11;

			// Team 2 : Gladiateur ////////
			Gladiator gladiator4 = new Gladiator ("Toutdou");
			gladiator4.addEquipment (new Dagger ());
			gladiator4.addEquipment (new SmallShield ());
			gladiator4.Priority = 3;

			Gladiator gladiator5 = new Gladiator ("Bisou");
			gladiator5.addEquipment (new Spear());
			gladiator5.addEquipment (new Helmet());
			gladiator5.Priority = 2;

			Gladiator gladiator6 = new Gladiator ("Calin");
			gladiator6.addEquipment (new Dagger ());
			gladiator6.addEquipment (new Net ());
			gladiator6.Priority = 1;

			team2.addGladiator (gladiator4);
			team2.addGladiator (gladiator5);
			team2.addGladiator (gladiator6);

			//-------------------------
			// Team 3 /////////
			Team team3 = new Team ("Les sombres", "Cartouche !!!", player3);
			team3.WinNumber = 12;
			team3.MatchPlayed = 26;

			// Team 3 : Gladiateur ////////
			Gladiator gladiator7 = new Gladiator ("Darkness");
			gladiator7.addEquipment (new Dagger());
			gladiator7.addEquipment (new LargeShield());
			gladiator7.Priority = 2;

			Gladiator gladiator8 = new Gladiator ("Noir");
			gladiator8.addEquipment (new Sword ());
			gladiator8.addEquipment (new Net ());
			gladiator8.Priority = 3;

			Gladiator gladiator9 = new Gladiator ("Ombre");
			gladiator9.addEquipment (new Trident());
			gladiator9.addEquipment (new Helmet());
			gladiator9.Priority = 1;

			team3.addGladiator (gladiator7);
			team3.addGladiator (gladiator8);
			team3.addGladiator (gladiator9);

			//-------------------------
			// Team 4 /////////
			Team team4 = new Team ("Les septs nains", "Bimm !!", player4);
			team4.WinNumber = 13;
			team4.MatchPlayed = 12;

			// Team 4 : Gladiateur ////////
			Gladiator gladiator10 = new Gladiator ("Grincheu");
			gladiator10.addEquipment (new Sword ());
			gladiator10.addEquipment (new Helmet ());
			gladiator10.Priority = 3;

			Gladiator gladiator11 = new Gladiator ("Dormeur");
			gladiator11.addEquipment (new Dagger());
			gladiator11.addEquipment (new LargeShield());
			gladiator11.Priority = 1;

			Gladiator gladiator12 = new Gladiator ("Timide");
			gladiator12.addEquipment (new Sword ());
			gladiator12.addEquipment (new Net ());
			gladiator12.Priority = 2;

			team4.addGladiator (gladiator10);
			team4.addGladiator (gladiator11);
			team4.addGladiator (gladiator12);

			//-------------------------
			// Team 5 /////////
			Team team5 = new Team ("Les Animaux", "On est des dingues !!!", player5);
			team5.WinNumber = 1;
			team5.MatchPlayed = 12;

			// Team 5 : Gladiateur ////////
			Gladiator gladiator13 = new Gladiator ("Dauphin");
			gladiator13.addEquipment (new Sword ());
			gladiator13.addEquipment (new Net ());
			gladiator13.Priority = 1;

			Gladiator gladiator14 = new Gladiator ("Cheval");
			gladiator14.addEquipment (new Dagger ());
			gladiator14.addEquipment (new Helmet ());
			gladiator14.Priority = 2;

			Gladiator gladiator15 = new Gladiator ("Chaton");
			gladiator15.addEquipment (new Sword ());
			gladiator15.addEquipment (new Net ());
			gladiator15.Priority = 3;

			team5.addGladiator (gladiator13);
			team5.addGladiator (gladiator14);
			team5.addGladiator (gladiator15);

			//-------------------------
			// Team 6 /////////
			Team team6 = new Team ("les Super heros", "Tigrou est notre ami", player6);
			team6.WinNumber = 6;
			team6.MatchPlayed = 20;

			// Team 6 : Gladiateur ////////
			Gladiator gladiator16 = new Gladiator ("Hulk");
			gladiator16.addEquipment (new Dagger ());
			gladiator16.addEquipment (new Helmet ());
			gladiator16.Priority = 3;

			Gladiator gladiator17 = new Gladiator ("Superman");
			gladiator17.addEquipment (new Trident ());
			gladiator17.addEquipment (new Helmet ());
			gladiator17.Priority = 2;

			Gladiator gladiator18 = new Gladiator ("Batman");
			gladiator18.addEquipment (new Sword ());
			gladiator18.addEquipment (new Net ());
			gladiator18.Priority = 1;

			team6.addGladiator (gladiator16);
			team6.addGladiator (gladiator17);
			team6.addGladiator (gladiator18);


			/*
			 * +--------------------------+
			 * |	Combat	     		  |
			 * +--------------------------+
			/* 

			/*	Ajouter une team au combat */
			Fight fight = new Fight ();
			fight.addTeamToFight(team1);
			fight.addTeamToFight(team2);
			fight.addTeamToFight(team3);
			fight.addTeamToFight(team4);
			fight.addTeamToFight(team5);
			fight.addTeamToFight(team6);

			Alert.showLine ();

			fight.initializeFight ();



		}
	}
}
