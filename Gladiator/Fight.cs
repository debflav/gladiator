using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator
{

	public class Fight
	{

		/**
		 * Collection Team
		 */
		private List<Team> _team = new List<Team>(); 
		public List<Team> Team {
			get { return this._team; }
		}

		/**
		 * Constructeur
		 */
		public Fight ()
		{
		}

		/**
		 * Ajouter une equipe au tournoi
		 * 
		 * Un joueur peut ajouter une seule équipe
		 */
		public void addTeamToFight(Team p_team)
		{
			// Regarde si le joueur a déjà une équipe dans le tournoi
			foreach (Team b_row in Team) {
				if( b_row.Owner.Pseudo == p_team.Owner.Pseudo) {
					Alert.showAlert ("Vous avez déjà une équipe dans le tournoi.");
					return;
				}
			}
			Team.Add(p_team);
		}

		/**
		 * (findOppponent) Trouve les adversaires suivant leur % de victoires
		 */
		public void initializeFight()
		{
			int countFighter = Team.Count;

			if (countFighter % 2 == 1) {
				Alert.showAlert ("Le combat ne peut pas commencer avec un nombre d'équipe impair.");
			}

			List<Team> sortByStrongestTeam = Team.OrderBy (s => s.getPercentVictory()).ToList();
			/*foreach (Team b_row in sortByStrongestTeam) {
				Console.WriteLine (b_row.getPercentVictory());
			}*/


		}


		// DEBUG ?
		public void teamListShow()
		{
			foreach (Team b_row in Team) {
				Console.WriteLine( "-" + b_row.TeamName + b_row.Owner.Pseudo);
			}
		}
	}
}

