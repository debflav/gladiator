using System;
using System.Collections.Generic;

namespace Gladiator
{
	public class Gladiator
	{

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
			get { return this._gladiatorLostNumber; }
			set { this._gladiatorLostNumber = value; }
		}


		private int _priority;
		public int Priority {
			get { return this._priority; }
			set { this._priority = value; }
		}


		private bool _inGame;
		public bool InGame {
			get { return this._inGame; }
			set { this._inGame = value; }
		}


		private List<Equipment> _equipment = new List<Equipment>(); 
		public List<Equipment> Equipment {
			get { return this._equipment; }
		}

		/**
		 * 
		 */
		public Gladiator ()
		{
		}

		/**
		 * 
		 */
		public int getPercentVictoy()
		{

		}

		/**
		 * 
		 */
		public void addEquipment()
		{

		}

		/**
		 * 
		 */
		public IAttaque attaquer()
		{

		}

		/**
		 * 
		 */
		public bool defend()
		{

		}
	}
}

