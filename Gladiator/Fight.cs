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
		 * Ajouter une equipe au tournoi.
		 * 
		 * Un joueur peut ajouter une seule équipe.
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
		 * Trouve les équipes qui vont combattre suivant leur pourcentage de victoire.
		 * Trouve les gladiateurs des équipes qui vont se combattre.
		 * Retourne l'équipe gagnante
		 */
		public void initializeFight()
		{
			int countTeam = Team.Count;

			// Le combat doit etre un nombre impair
			if (countTeam % 2 == 1) {
				Alert.showAlert ("Le combat ne peut pas commencer. Il manque une équipe.");
			}

			int countFight = 1;
			// Boucle sur le nombre d'équipes
			while(countFight < countTeam) {
				countFight++;

				List<Team> sortByStrongestTeam = (from b_team in Team
			                                      orderby b_team.getPercentVictory() descending
			                                      where b_team.InGame == true
			                                      select b_team).Take(2).ToList();

				do {
					List<Gladiator> gladiators = this.getTwoOpponents (sortByStrongestTeam);

					if (gladiators.Count == 2) {
						Duel duel = new Duel (gladiators [0], gladiators [1]);
						Gladiator glad = duel.InTheArena ();
						if(glad == null) {
							Alert.showAlert("Les deux adversaires se sont entretués; les idiots =)");
						} else {
							Alert.showGladiator (glad);
						}
					}
				} while(sortByStrongestTeam[0].teamGladiatorInGame() && sortByStrongestTeam[1].teamGladiatorInGame());

				// L'équipe qui n'a plus de gladiateurs est retiré du tournoi (à voir si InGame est utile pour la team)
				// L'autre équipes voit le status de tous ses gladiateurs remis à true
				foreach (Team b_team in sortByStrongestTeam) {
					bool noMoreGladiator = b_team.teamGladiatorInGame();
					if (noMoreGladiator == false) {
						this.Team.Remove (b_team);
					} else {
						foreach (Gladiator b_glad in b_team.Gladiator) {
							b_glad.InGame = true;
						}
					}
				}
			}
			// Method winner !!! (ou pas)
			foreach(Team b_team in Team) {
				Alert.showAlert ("La team \"" + b_team.TeamName + "\" a gagnée. Hip hip hip !!!");
			}
		}
		

		/**
		 * Retourne une liste de gladiateurs comportant les deux adversaires.
		 */ 
		public List<Gladiator> getTwoOpponents(List<Team> _twoTeam)
		{
			List<Gladiator> gladiators = new List<Gladiator>();
			// Sélection des deux equipes les plus fortes
			foreach (Team b_rowT in _twoTeam) {

				// Sélection des deux joueurs avec la plus grande priorité
				Gladiator gladiator = b_rowT.gladiatorByPriority ();

				if (gladiator == null) {
					break;
				}

				gladiators.Add (gladiator);

			}

			return gladiators;
		}

	}
}

