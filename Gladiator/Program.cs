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

//			player1.ajouterEquipe (team1);
//			player1.ajouterEquipe (team2);

			/* Ajout d'un gladiateur */
			//Gladiator.

			/* Ajout de gladiateurs à une équipe */
			//team1.addGladiator (team1);
		}
	}
}
