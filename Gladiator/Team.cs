using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator
{
	public class Team
	{

		private Player _owner;
		public Player Owner {
			get { return _owner; }
			set {_owner = value; }
		}

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
		private int _teamDefeatNumber;
		public int TeamDefeatNumber {
			get { return this._teamDefeatNumber; }
			set { this._teamDefeatNumber = value; }
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
		 * Collection Gladiateur
		 */
		private List<Gladiator> _gladiator = new List<Gladiator>(); 
		public List<Gladiator> Gladiator {
			get { return this._gladiator; }
		}


		/**
		 * Crée une équipe à l'instanciation de la classe
		 */
		public Team (string p_teamName, string p_description, Player p_owner)
		{
			this.TeamName 	 = p_teamName;
			this.Description = p_description;
			this.Owner = p_owner;
			Owner.addTeam (this);

			// Incremente le numéro de l'equipe
			Team._teamNumber++;
		}


		/**
		 * Ajouter un gladiateur à une équipe passée en paramètre
		 * 
		 * Une équipe est composée de trois gladiateurs maximum
		 * Retourne true si l'execution s'est bien déroulée
		 */
		public bool addGladiator(Gladiator p_gladiator)
		{

			if(p_gladiator.GladiatorTeam != null) {
				throw new Exception ("Gladiateur : " + p_gladiator.GladiatorName + " déjà dans une team");
			}
			// Regarde le nombre de gladiateurs actuels
			int countGladiators = Gladiator.Count;

			if(countGladiators >= 3) {
				return false;
			}

			// Un nom de gladiateur doit exister une seule fois
			foreach (Gladiator b_row in Gladiator) {
				if (b_row.GladiatorName == p_gladiator.GladiatorName) {
					return false;
				}
			}

			// Insertion de l'équipe dans la collection
			try {
				this.Gladiator.Add (p_gladiator);
				p_gladiator.GladiatorTeam = this;
			} catch(Exception) {
				throw new Exception ("Something wrong append.");
			}

			return true;
		}


		/**
		 * Affichage des gladiateurs dans l'équipe
		 */
		public void showGladiatorsFromTeam()
		{
			// Regarder le nombre de gladiateurs actuels dans l'équipe
			int countGladiators = Gladiator.Count;

			if (countGladiators == 0) {
				Console.WriteLine ("Aucun joueur dans l'équipe " + this.TeamName);
			} else {
				// Affichage des équipes
				if (countGladiators == 1) {
					Console.WriteLine ("Un seul gladiateur dans l'équipe " + this.TeamName + ":");
				} else {
					Console.WriteLine ("Les gladiateurs de l'équipe " + this.TeamName + " sont: ");
				}
				foreach (Gladiator b_row in Gladiator) {
					Console.WriteLine (b_row.GladiatorName);
				}
			}
		}


		/**
		 * Supprimer un gladiateur de l'équipe
		 * 
		 * Retourne true si l'execution s'est bien déroulée
		 */
		public void deleteGladiatorFromTeam(Gladiator p_gladiator)
		{
			try {
				Gladiator.Remove( p_gladiator);
			} catch(Exception) {
				throw new Exception ("La suppression a échoué.");
			}
		}


		/**
		 * Retourne le pourcentage de victoire de l'équipe.
		 */
		public double getPercentVictory()
		{
			return (double)this.WinNumber*(double)100/(double)this.MatchPlayed;
		}


		/**
		 * Retourne le premier gladiateur de l'équipe (par priorité).
		 * Si l'équipe n'a plus de gladiateur disponible return un gladiateur null.
		 */
		public Gladiator gladiatorByPriority()
		{
			List<Gladiator> sortByGladiatorPriority = new List<Gladiator>();
			Gladiator oneGladiator = null;

			sortByGladiatorPriority = (from b_glad in Gladiator
			                           orderby b_glad.Priority descending
			                           where b_glad.InGame == true
			                           select b_glad).Take(1).ToList();

			foreach(Gladiator b_rowGlad in sortByGladiatorPriority) {
				oneGladiator = b_rowGlad;
				Alert.showAlert (oneGladiator.GladiatorName + " " + oneGladiator.Priority);
			}

			return oneGladiator;
		}


		/**
		 * Retourne vrai si l'équipe possède encore des gladiateurs
		 * en lice, sinon retourne faux.
		 */
		public bool teamGladiatorInGame()
		{
			foreach (Gladiator b_glad in Gladiator) {
				if (b_glad.InGame) {

					return true;
				}
			}

			return false;
		}

	}
}

