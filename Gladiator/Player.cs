using System;
using System.Collections.Generic;

namespace Gladiator
{
	public class Player
	{
		/**
		 * Nom String
		 */
		private string _lastname;
		public string Lastname {
			get { return this._lastname; }
			set { this._lastname = value; }
		}

		/**
		 * Prenom String
		 */
		private string _firstname;
		public string Firstname {
			get { return this._firstname; }
			set { this._firstname = value; }
		}

		/**
		 * Pseudo String
		 */
		private string _pseudo;
		public string Pseudo {
			get { return this._pseudo; }
			set { this._pseudo = value; }
		}

		/**
		 * Date d'inscription DateTime
		 */
		private DateTime _registrationDate;
		public DateTime RegistrationDate {
			get { return this._registrationDate; }
			set { this._registrationDate = value; }
		}

		/**
		 * Collection Team
		 */
		private List<Team> _team = new List<Team>(); 
		public List<Team> Team {
			get { return this._team; }
		}

		/**
		 * Constructeur de Player
		 */
		public Player (string p_lastname, string p_firstname, string p_pseudo, DateTime p_registrationDate)
		{
			this.Lastname 			= p_lastname;
			this.Firstname 			= p_firstname;
			this.Pseudo 			= p_pseudo;
			this.RegistrationDate 	= p_registrationDate;
		}

		/**
		 * Ajouter une equipe au joueur.
		 * 
		 * Chaque joueur peut créer jusqu'à 5 équipes de gladiateurs.
		 */
		public void ajouterEquipe(Team p_team)
		{
			// Compte le nombre d'équipe actuel pour le joueur
			int teamNumber = _team.Count;

			if(teamNumber == 5) {
				throw new Exception ("Limite du nombre d'équipe fixé à cinq");
			}

			// Insertion de l'équipe dans la collection
			try {
				this._team.Add (p_team);
			} catch(Exception) {
				throw new Exception ("Something wrong append.");
			}

			// Affichage des équipes
			Console.WriteLine( "Les équipes sont:");

			foreach (Team b_row in _team) {
				Console.WriteLine( b_row.TeamName);
			}
			Console.WriteLine( "-------------------------------");
		}
	}
}

