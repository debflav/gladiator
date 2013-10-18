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

		public Gladiator InTheArena(){

			int tour = 0;
			bool isDamageForGladiator1 = false;
			bool isDamageForGladiator2 = false;

			// Tant que les 2 gladiateur sont en jeu de pas sortir de la boucle
			while (this.Gladiator1.InGame && this.Gladiator2.InGame ) {

				Equipment gladiator1Equipment = this.Gladiator1.attack (true);
				Equipment gladiator2Equipment = this.Gladiator2.attack (true);
			
				// L'attaquant utiliser le filet
				if (gladiator1Equipment != null && gladiator1Equipment is Equipments.Attack.Net) {
					isDamageForGladiator2 = true;
				}
				if (gladiator2Equipment != null && gladiator2Equipment is Equipments.Attack.Net) {
					isDamageForGladiator1 = true;
				}

				// L'attaquant est mutilé
				if (isDamageForGladiator1 && gladiator1Equipment != null) {
				
					((IAttack)gladiator1Equipment).downDamage ();
					 
				}

				if (gladiator1Equipment == null) {

					Alert.showAlert ("gladiator1Equipment == null");
					this.Gladiator1.InGame = false;

				} else if (gladiator2Equipment == null) {

					Alert.showAlert ("gladiator2Equipment == null");
					this.Gladiator2.InGame = false;

				} else if (gladiator1Equipment.Priority == gladiator2Equipment.Priority) {

					Alert.showAlert ("gladiator1Equipment.Priority == gladiator2Equipment.Priority");
					this.Gladiator2.defend (gladiator1Equipment);
					this.Gladiator1.defend (gladiator2Equipment);

				} else if (gladiator1Equipment.Priority > gladiator2Equipment.Priority) {

					Alert.showAlert ("gladiator1Equipment.Priority > gladiator2Equipment.Priority");
					this.Gladiator2.defend (this.Gladiator1.attack(true));

				} else if (gladiator1Equipment.Priority < gladiator2Equipment.Priority)  {
				
					Alert.showAlert ("gladiator1Equipment.Priority < gladiator2Equipment.Priority");
					this.Gladiator1.defend (this.Gladiator2.attack(true));
					
				}

				tour++;

			}

			//vérifier gagnant
			// Retourne null si les deux gladiateur se tue.
			if (!this.Gladiator1.InGame && !this.Gladiator2.InGame) {

				return null;
			} else if (this.Gladiator2.InGame) {

				return this.Gladiator2;
			} else {

				return this.Gladiator1;
			}
	

		}


	}
}

