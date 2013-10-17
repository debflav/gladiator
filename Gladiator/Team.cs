using System;
using System.Collections.Generic;

namespace Gladiator
{
	public class Team
	{

		/**
		 * Numéro d'equipe Static int
		 */
		private static int _teamNumber = 1;
		public static int TeamNumber {
			get { return Team._teamNumber; }
			set { Team._teamNumber = value; }
		}


		/**
		 * Nom de l'équipe String
		 */ 
		private string _teamName;
		public string TeamName {
			get { return this._teamName; }
			set { this._teamName = value; }
		}


		/**
		 * Description String
		 */
		private string _description;
		public string Description {
			get { return this._description; }
			set { this._description = value; }
		}


		/**
		 * Nombre de victoire Int
		 */
		private int _winNumber;
		public int WinNumber {
			get { return this._winNumber; }
			set { this._winNumber = value; }
		}


		/**
		 * Nombre de défaite Int
		 */
		private int _defeatNumber;
		public int DefeatNumber {
			get { return this._defeatNumber; }
			set { this._defeatNumber = value; }
		}

		/**
		 * Nombre de match joué Int
		 */
		private int _matchPlayed;
		public int MatchPlayed {
			get { return this._matchPlayed; }
			set { this._matchPlayed = value; }
		}


		/**
		 * Partie en cours Bool
		 */
		private bool _inGame;
		public bool InGame {
			get { return this._inGame; }
			set { this._inGame = value; }
		}

		/**
		 * Collection Gladiator
		 */
		private List<Gladiator> _gladiator = new List<Gladiator>(); 
		public List<Gladiator> Gladiator {
			get { return this._gladiator; }
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
		 * Ajouter un gladiateur à l'équipe
		 * 
		 * Une équipe est composée de trois gladiateurs maximum
		 * Retourne true si l'execution s'est bien déroulée
		 */
		public bool addGladiator(Gladiator p_gladiator)
		{
			// Regarder le nombre de gladiateurs actuels

			//this._gladiator.Count;

			return true;
		}

		/**
		 * Supprimer un gladiateur de l'équipe
		 * 
		 * Retourne true si l'execution s'est bien déroulée
		 */
		public bool deleteGladiator()
		{


			return true;
		}

		/**
		 * Obtenir le pourcentage de victoire
		 * 
		 * 
		 */
		/*public double getPercentVictoy()
		{

		}*/

	}
}

