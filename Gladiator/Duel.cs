using System;
using Equipments;

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


		protected Gladiator getFirstCombattant(){

			Equipment gladiator1Equipment = this.Gladiator1.attack (true);
			Equipment gladiator2Equipment = this.Gladiator2.attack (true);

			if (gladiator1Equipment == null || gladiator2Equipment == null) {
				Alert.showAlert ("fuck");
				return null;

			} else if (gladiator1Equipment.Priority > gladiator2Equipment.Priority) {
				return this.Gladiator1;

			} else if (gladiator1Equipment.Priority == gladiator2Equipment.Priority) {

				return null;

			} else {
				return this.Gladiator2;
			}
		
		}
		protected Gladiator getSecondCombattant(){

			Equipment gladiator1Equipment = this.Gladiator1.attack (true);
			Equipment gladiator2Equipment = this.Gladiator2.attack (true);

			if (gladiator1Equipment == null || gladiator2Equipment == null) {
				Alert.showAlert ("fuck");
				return null;

			} else if (gladiator1Equipment.Priority < gladiator2Equipment.Priority) {
				return this.Gladiator1;
			} else {
				return this.Gladiator2;
			}

		}

		public Gladiator InTheArena(){

			int tour = 0;

			// Tant que les 2 gladiateur sont en jeu de pas sortir de la boucle
			while (this.Gladiator1.InGame && this.Gladiator2.InGame ) {

	
				Equipment gladiator1Equipment = this.Gladiator1.attack (false);
				Equipment gladiator2Equipment = this.Gladiator2.attack (false);

				if (gladiator1Equipment == null) {

					this.Gladiator1.InGame = false;

				} else if (gladiator2Equipment == null) {

					this.Gladiator2.InGame = false;

				} else if (gladiator1Equipment.Priority == gladiator2Equipment.Priority) {

					this.Gladiator2.defend (this.Gladiator1.attack(true));
					this.Gladiator1.defend (this.Gladiator2.attack(true));

				} else if (gladiator1Equipment.Priority > gladiator2Equipment.Priority) {

					this.Gladiator2.defend (this.Gladiator1.attack(true));

				} else if (gladiator1Equipment.Priority < gladiator2Equipment.Priority)  {
				
					this.Gladiator1.defend (this.Gladiator2.attack(true));
					
				}

				tour++;

			}

			//vérifier gagnant
			if (this.Gladiator1.InGame) {
				return this.Gladiator1;
			}else{
				return this.Gladiator2;
			}


		}


	}
}

