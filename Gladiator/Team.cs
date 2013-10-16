using System;
using System.Collections.Generic;

namespace Gladiator
{
	public class Team
	{

		private static int _teamNumber = 1;
		public static int TeamNumber {
			get { return Team._teamNumber; }
			set { Team._teamNumber = value; }
		}

		private string _teamName;
		public string TeamName {
			get { return this._teamName; }
			set { this._teamName = value; }
		}

		private string _description;
		public string Description {
			get { return this._description; }
			set { this._description = value; }
		}

		private int _winNumber;
		public int WinNumber {
			get { return this._winNumber; }
			set { this._winNumber = value; }
		}

		private int _lostNumber;
		public int LostNumber {
			get { return this._lostNumber; }
			set { this._lostNumber = value; }
		}
		
		private int _matchNumber;
		public int MatchNumber {
			get { return this._matchNumber; }
			set { this._matchNumber = value; }
		}
		
		private bool _inGame;
		public bool InGame {
			get { return this._inGame; }
			set { this._inGame = value; }
		}


		/**
		 * Crée une équipe à l'instanciation de la classe
		 */
		public Team (string p_teamName, string p_description)
		{
			this.TeamName 			= p_teamName;
			this.Description 		= p_description;

			// Incremente le numéro de l'equipe
			Team._teamNumber++;
		}

		/**
		 * 
		 * 
		 */
		public bool addGladiator()
		{

		}

		/**
		 * 
		 * 
		 */
		public bool deleteGladiator()
		{

		}

		/**
		 * 
		 * 
		 */
		public double getPercentVictoy()
		{

		}

	}
}

