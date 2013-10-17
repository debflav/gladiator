using System;
using System.Collections.Generic;
using Equipments;

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
		public int GladiatorLostNumber {
			get { return this._gladiatorDefeatNumber; }
			set { this._gladiatorDefeatNumber = value; }
		}


		private int _priority;
		public int Priority {
			get { return this._priority; }
			set { this._priority = value; }
		}


		private bool _inGame = false;
		public bool InGame {
			get { return this._inGame; }
			set { this._inGame = value; }
		}


		private List<Equipment> _equipment;
		public List<Equipment> Equipment {
			get { return this._equipment; }
			set { this._equipment = value; }
		}

		/**
		 * 
		 */
		public Gladiator (string name)
		{
			this.GladiatorName = name;
			this.Equipment = new List<Equipment>();
			this.NbEquipmentCurent = 0;
		}
		// ----------------------------------------

		/**
		 * Calcule du poucentage de victoir
		 */
		public double getPercentVictoy()
		{
			int nbVictory = this.GladiatorWinNumber;
			int nbDefeat = this.GladiatorLostNumber;
			int NbMatchToPlay = nbVictory + nbDefeat;

			return (double)nbVictory*(double)100/(double)NbMatchToPlay;
		}

		/**
		 * Ajouter un equipement à sa liste d'equipement
		 * Avec test sur le nombre de points de équipments
		 */
		public void addEquipment(Equipment onEquipment)
		{
			int nbPointEquipment = onEquipment.Point;

			if ((nbPointEquipment + this.NbEquipmentCurent) <= NB_MAX_EQUIPMENT) {
				this.Equipment.Add (onEquipment);
				this.NbEquipmentCurent = this.NbEquipmentCurent + nbPointEquipment;
			} else {

				Alert.showAlert ("Le nombre d'équipement max est atteint ! ");
			}

		}

		/**
		 * 
		 */
		/*public IAttaque attaquer()
		{

		}*/

		/**
		 * 
		 */
		/*public bool defend()
		{

		}*/
	}
}

