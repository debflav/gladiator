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

			// rechercher les equipements
			foreach(Equipment onEquiment in this.Equipments){
				if (onEquiment.Use) {
					if (equipment < onEquiment.Priority) {
						equipment = onEquiment.Priority;
					}
				}

			}

			return equipment;

//			if (equipement == 1) {
//				foreach(Equipment onEquiment in this.Equipments){
//					if (onEquiment == equipement) {
//						return 1;
//						this.Equipments.Remove (onEquiment);
//					}
//				}
//			}
		}

		/**
		 * 
		 */
		/*public bool defend()
		{

		}*/
	}
}

