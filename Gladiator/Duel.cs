using System;
using Equipments;
using Equipments.Interfaces;

namespace Gladiator
{
	public class Duel
	{

		private Gladiator _gladiator1;
		public Gladiator Gladiator1 {
			get { return this._gladiator1; }
			set	{ this._gladiator1 = value; }
		}

		private Gladiator _gladiator2;
		public Gladiator Gladiator2 {
			get { return this._gladiator2; }
			set { this._gladiator2 = value; }
		}

		public Duel (Gladiator gladiator1, Gladiator gladiator2)
		{
			this.Gladiator1 = gladiator1;
			this.Gladiator2 = gladiator2;
		}

		public void ifUseNet(Equipment p_equipement, Gladiator p_gladiator){

			if (p_equipement != null && p_equipement is Equipments.Attack.Net) {
				Alert.showAlert("///// filet sur " + p_gladiator.GladiatorName);
				p_gladiator.downDamage ();
			}

		}

		public Gladiator InTheArena(){

			int tour = 1;

			Alert.showAlert ("DEBUT DU DUEL");
			Alert.showAlert ("-------------");
			Alert.showAlertWith ("Gladiateur 1: equipe", (this.Gladiator1.GladiatorTeam.TeamName).ToString());
			Alert.showAlertWith ("Gladiateur 2: equipe", (this.Gladiator2.GladiatorTeam.TeamName).ToString());
			Alert.showAlertWith ("Gladiateur 1", (this.Gladiator1.GladiatorName).ToString());
			Alert.showAlertWith ("Gladiateur 2", (this.Gladiator2.GladiatorName).ToString());


			// Tant que les 2 gladiateur sont en jeu de pas sortir de la boucle
			while (this.Gladiator1.InGame && this.Gladiator2.InGame ) {

				Alert.showAlert ("-------------");
				Alert.showAlertWith ("JOUTE ", tour.ToString());
				Alert.showAlert ("-------------");

				Equipment gladiator1Equipment = this.Gladiator1.attack ();
				Equipment gladiator2Equipment = this.Gladiator2.attack ();

				if (gladiator1Equipment == null && gladiator2Equipment == null) {

					Alert.showAlert ("Personne n'est mort, on recommence une nouvelle joute !");
					this.Gladiator1.rearmament ();
					this.Gladiator2.rearmament ();

				} else if (gladiator1Equipment == null) {

					Alert.showAlert (this.Gladiator2.GladiatorName + " attaque avec " + gladiator2Equipment.Name); 
					gladiator2Equipment.Use = true;
					this.Gladiator1.defend (gladiator2Equipment);

				} else if (gladiator2Equipment == null) {

					Alert.showAlert (this.Gladiator1.GladiatorName + " attaque avec " + gladiator1Equipment.Name); 
					gladiator1Equipment.Use = true;
					this.Gladiator2.defend (gladiator1Equipment);

				} else if (gladiator1Equipment.Priority == gladiator2Equipment.Priority) {


					Alert.showAlert ("Equipement sont égaux les deux gladiateur vont attaquer");
					gladiator1Equipment.Use = true;
					Alert.showAlert (this.Gladiator1.GladiatorName + " attaque avec " + gladiator1Equipment.Name); 
					this.Gladiator2.defend (gladiator1Equipment);


					gladiator2Equipment.Use = true;
					Alert.showAlert (this.Gladiator2.GladiatorName + " attaque avec " + gladiator2Equipment.Name); 
					this.Gladiator1.defend (gladiator2Equipment);

				} else if (gladiator1Equipment.Priority > gladiator2Equipment.Priority || gladiator2Equipment == null ) {

					gladiator1Equipment.Use = true;

					Alert.showAlert (this.Gladiator1.GladiatorName + " attaque avec " + gladiator1Equipment.Name); 
					this.Gladiator2.defend (gladiator1Equipment);

				} else if (gladiator1Equipment.Priority < gladiator2Equipment.Priority || gladiator1Equipment == null)  {

					gladiator2Equipment.Use = true;

					Alert.showAlert (this.Gladiator2.GladiatorName + " attaque avec " + gladiator2Equipment.Name);
					this.Gladiator1.defend (gladiator2Equipment);
					
				}

				tour++;

			}

			// Vérifier gagnant
			// Retourne null si les deux gladiateur se tue.
			if (!this.Gladiator1.InGame && !this.Gladiator2.InGame) {
				this.Gladiator1.GladiatorDefeatNumber += 1;
				this.Gladiator2.GladiatorDefeatNumber += 1;

				return null;

			} else if (this.Gladiator2.InGame) {

				this.Gladiator2.rearmament ();

				this.Gladiator2.GladiatorWinNumber += 1;
				this.Gladiator1.GladiatorDefeatNumber += 1;

				return this.Gladiator2;
			} else {

				this.Gladiator1.rearmament ();

				this.Gladiator1.GladiatorWinNumber += 1;
				this.Gladiator2.GladiatorDefeatNumber += 1;

				return this.Gladiator1;
			}
	

		}


	}
}

