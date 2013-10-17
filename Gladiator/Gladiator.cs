using System;
using System.Collections.Generic;
using Equipments;
using Equipments.Interfaces;
using Equipments.Attack;
using Equipments.DefendAndAtack;

namespace Gladiator
{
	public class Gladiator
	{

		const int NB_MAX_EQUIPMENT = 10;
		private Random _ramdom;

		// Constructeur --------------------------------
		private int _nbEquipmentCurent;
		public int NbEquipmentCurent {
			get { return this._nbEquipmentCurent; }
			set { this._nbEquipmentCurent = value; }
		}


		private string _gladiatorName;
		public string GladiatorName {
			get { return this._gladiatorName; }
			set { this._gladiatorName = value; }
		}


		private int _gladiatorWinNumber;
		public int GladiatorWinNumber {
			get { return this._gladiatorWinNumber; }
			set { this._gladiatorWinNumber = value; }
		}


		private int _gladiatorDefeatNumber;
		public int GladiatorDefeatNumber {
			get { return this._gladiatorDefeatNumber; }
			set { this._gladiatorDefeatNumber = value; }
		}


		private int _priority;
		public int Priority {
			get { return this._priority; }
			set { 
				if (value <= 3 && value > 0) {
					this._priority = value; 
				} else {
					Alert.showAlert ("Choisir un nombre entre 1 et 3");
				}
				}
		}


		private bool _inGame = false;
		public bool InGame {
			get { return this._inGame; }
			set { this._inGame = value; }
		}


		private List<Equipment> _equipments;
		public List<Equipment> Equipments {
			get { return this._equipments; }
			set { this._equipments = value; }
		}

		private List<Equipment> _equipmentsAttack;
		public List<Equipment> EquipmentsAttack {
			get { return this._equipmentsAttack; }
			set { this.EquipmentsAttack = value; }
		}

		/**
		 * Constructeur
		 */
		public Gladiator (string name)
		{
			this.GladiatorName = name;
			this.Equipments = new List<Equipment>();
			this.NbEquipmentCurent = 0;
			this._ramdom = new Random ();
		}
		// ----------------------------------------

		/**
		 * Calcule du poucentage de victoir
		 * 
		 * @return	Double	pourcentage victoir
		 */
		public double getPercentVictory()
		{
			int nbVictory = this.GladiatorWinNumber;
			int nbDefeat = this.GladiatorDefeatNumber;
			int NbMatchToPlay = nbVictory + nbDefeat;

			return (double)nbVictory*(double)100/(double)NbMatchToPlay;
		}

		/**
		 * Ajouter un equipement à sa liste d'equipement
		 * Avec test sur le nombre de points de équipments
		 * 
		 * @param	Equipment unEquipement
		 */
		public void addEquipment(Equipment onEquipment)
		{
			int nbPointEquipment = onEquipment.Point;

			if ((nbPointEquipment + this.NbEquipmentCurent) <= NB_MAX_EQUIPMENT) {
				this.Equipments.Add (onEquipment);
				this.NbEquipmentCurent = this.NbEquipmentCurent + nbPointEquipment;
			} else {
				int reste = NB_MAX_EQUIPMENT - this.NbEquipmentCurent ;
				Alert.showAlert ("Il reste " + reste.ToString() + " point(s) d'équipement au gladiateur !");
			}

		}


		/**
		 * Renvois une arme au moment de l'attaque
		 * Avec ordre d'initiative des armes (Filet - Lance - Trident - Épée - Dague
		 * 
		 * @return	int	chance de toucher l'adversaire
		 */
		public int attack()
		{
			int equipment = 0;
			int luckyTouch = 0;

			// rechercher les equipements le plus fort
			foreach(Equipment onEquiment in this.Equipments){
				if (onEquiment.Use) {
					if (equipment < onEquiment.Priority) {
						equipment = onEquiment.Priority;
					}
				}

			}

			// mettre l'équipement trouver a false (pour ne pas le réutiliser)
			foreach(Equipment onEquiment in this.Equipments){
				if (onEquiment is IAttack && onEquiment.Priority == equipment) {
					onEquiment.Use = false;
					luckyTouch = onEquiment.Point;
				}
			}

			return luckyTouch;

		}

		/**
		 * Renvois un true or false si le gladiateur est mort
		 *
		 * @param	int		Chance que l'arme à de toucher l'adversaire;
		 * @return	bool	pour voir si le gladiateur est tuer
		 */
		public bool defend(int luckyTouch)
		{
			int i = 0;
			int countDefend = 0;
			int touch = 0;

			// Compte le nombre de protection;
			foreach (Equipment oneEquipment in this.Equipments) {
			
				if (oneEquipment is IDefend) {
					countDefend++;
				}
				
			}

			while(i <= luckyTouch/10){

				// Random pour le toucher
				int myNbRandom = this._ramdom.Next (0, 10);
				//Alert.showAlert("nbramdome = " + myNbRandom.ToString());
				// si le gladiateur est touché
				if (myNbRandom > 5) {

					// Protection
					foreach (Equipment onEquiment in this.Equipments) {
						//si arme de protection
						if (onEquiment is IDefend && onEquiment.Use == true) {

							//protection chance de toucher
							for(int j = 0; j<=onEquiment.LuckyParry/10; j++){
								myNbRandom = this._ramdom.Next (0, 10);

								if (myNbRandom > 5) {
									onEquiment.Use = false;
									touch++;
								}
							}

						}

					}

					i = luckyTouch / 10;

				}
				i++;

			}

			if (touch >= countDefend) {
				return true;
			} else {
				return false;
			}

		}
	}
}

