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
		 *  Trouve les équipes qui vont combattre suivant leur pourcentage
		 *  de victoire (les plus fortes contre les plus fortes).
		 */
		public void initializeFight()
		{
			int countTeam = Team.Count;

			if (countTeam % 2 == 1) {
				Alert.showAlert ("Le combat ne peut pas commencer avec un nombre d'équipe impair.");
			}


			int countFight = 0;
			// Boucle sur le nombre d'équipes
			while(countFight < countTeam/4) {
				countFight++;

				List<Team> sortByStrongestTeam = (from b_team in Team
			                                      orderby b_team.getPercentVictory() descending
			                                      where b_team.InGame == false
			                                      select b_team).Take(2).ToList();

				List<Gladiator> gladiators = new List<Gladiator>();

				// Sélection des deux equipes les plus fortes
				foreach (Team b_rowT in sortByStrongestTeam) {
					b_rowT.InGame = true;

					// Sélection des deux joueurs avec la plus grande priorité
					Gladiator gladiator = b_rowT.gladiatorByPriority ();

					if (gladiator == null) {
						break;
					}

					gladiators.Add (gladiator);
					//Console.WriteLine (gladiator.GladiatorName);

					/*foreach(Gladiator b_rowG in gladiators) {
						Alert.showAlert ( b_rowG.GladiatorName);
					}*/


				}
				Duel duel = new Duel (gladiators[0], gladiators[1]);
				Gladiator glad = duel.InTheArena ();
				Alert.showGladiator (glad);
			}
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

