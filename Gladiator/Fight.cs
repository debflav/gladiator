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
			foreach (Team b_rowTeam in Team) {
				if( b_rowTeam.Owner.Pseudo == p_team.Owner.Pseudo) {
					Alert.showAlert ("Vous avez déjà une équipe dans le tournoi.");
					return;
				}
			}

			Team.Add(p_team);
		}

		/**
		 * Trouve les équipes qui vont combattre suivant leur pourcentage de victoire.
		 * Trouve les gladiateurs des équipes qui vont se combattre.
		 * Retourne l'équipe gagnante.
		 */
		public void initializeFight()
		{
			int countTeam = Team.Count;

			// Le combat doit être un nombre impair.
			if (countTeam % 2 == 1) {
				Alert.showAlert ("Le combat ne peut pas commencer. Il manque une équipe.");
				return;
			}

			int countFight = 1;
			while(countFight < countTeam) {
				countFight++;

				// Donne les deux équipes toujours en lice dont le pourçentage de victoire est le plus élevé.
				List<Team> sortByStrongestTeam = (from b_team in Team
			                                      orderby b_team.getPercentVictory() descending
			                                      select b_team).Take(2).ToList();

				// Tant que les équipes ont des gladiateurs disponible au combat.
				do {
					List<Gladiator> gladiators = this.getTwoOpponents (sortByStrongestTeam);


						Duel duel = new Duel (gladiators [0], gladiators [1]);
						Gladiator glad = duel.InTheArena ();
						if(glad == null) {
							Alert.showAlert("Les deux adversaires se sont entretués; les idiots =)");
						} else {
							Alert.showyellowAlert("Gagnant du duel : " + glad.GladiatorName);
						}
				} while(sortByStrongestTeam[0].teamGladiatorInGame() && sortByStrongestTeam[1].teamGladiatorInGame());

				this.roundEndBetweenTwoTeam (sortByStrongestTeam);
			}

			foreach(Team b_team in Team) {
				Alert.showAlert ("La team \"" + b_team.TeamName + "\" a gagnée le tournoi. Hip hip hip !!!");
				Alert.showAlert ("Matchs gagnés: " + b_team.WinNumber + ". Matchs perdus: " + b_team.TeamDefeatNumber +"." + " Match jouées: " + b_team.MatchPlayed);
			}
		}
		

		/**
		 * Retourne une liste de gladiateurs comportant les deux adversaires qui vont s'affronter.
		 */ 
		public List<Gladiator> getTwoOpponents(List<Team> _twoTeam)
		{
			List<Gladiator> gladiators = new List<Gladiator>();

			foreach (Team b_rowTeam in _twoTeam) {
				Gladiator oneGladiator = b_rowTeam.gladiatorByPriority ();

				if (oneGladiator == null) {
					break;
				}

				gladiators.Add (oneGladiator);
			}

			return gladiators;
		}

		 
		/**
		 * - L'équipe qui n'a plus de gladiateurs est retiré du tournoi. Son nombre de défaite est incrémenté de un.
		 * - L'équipe gagnante voit le status de tous ses gladiateurs remis à true pour le prochain combat.
		 * Son nombre de victoire est incrémenté de un.
		 */
		public void roundEndBetweenTwoTeam(List<Team> sortByStrongestTeam)
		{
			foreach (Team b_rowTeam in sortByStrongestTeam) {
				bool noMoreGladiator = b_rowTeam.teamGladiatorInGame();			
				b_rowTeam.MatchPlayed++;
				if (noMoreGladiator == false) {
					b_rowTeam.TeamDefeatNumber++;
					this.Team.Remove (b_rowTeam);
					Alert.showRedAlert(b_rowTeam.TeamName + " à perdu le match !");


				} else {
					b_rowTeam.WinNumber++;
					Alert.showyellowAlert(b_rowTeam.TeamName + " à gagné le match !");
					foreach (Gladiator b_glad in b_rowTeam.Gladiator) {
						b_glad.InGame = true;
					}
				}
			}
		}

	}
}

