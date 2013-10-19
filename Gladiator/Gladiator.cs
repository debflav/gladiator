using System;
using System.Collections.Generic;
using Equipments;
using Equipments.Interfaces;
using Equipments.Attack;
using Equipments.DefendAndAtack;
using System.Security.Cryptography;

namespace Gladiator
{
	public class Gladiator
	{

		private Random _ramdom;

		// Constructeur --------------------------------
		private const int _NB_MAX_EQUIPMENT = 10;
		public int NB_MAX_EQUIPMENT{
			get { return _NB_MAX_EQUIPMENT; }
		}

		private int _nbEquipmentCurent;
		public int NbEquipmentCurent {
			get { return this._nbEquipmentCurent; }
			set { this._nbEquipmentCurent = value; }
		}

		private int _nbPointDefence;
		public int NbPointDefence {
			get { return this._nbPointDefence; }
			set { this._nbPointDefence = value; }
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
		public int GladiatorDefeatNumber {
			get { return this._gladiatorDefeatNumber; }
			set { this._gladiatorDefeatNumber = value; }
		}


		private int _priority;
		public int Priority {
			get { return this._priority; }
			set { 
				if (value <= 3 && value > 0) {
					this._priority = value; 
				} else {
					Alert.showAlert ("Choisir un nombre entre 1 et 3");
				}
				}
		}


		private bool _inGame = false;
		public bool InGame {
			get { return this._inGame; }
			set { this._inGame = value; }
		}


		private List<Equipment> _equipments;
		public List<Equipment> Equipments {
			get { return this._equipments; }
			set { this._equipments = value; }
		}


		/**
		 * Constructeur
		 */
		public Gladiator (string name)
		{
			this.GladiatorName = name;
			this.Equipments = new List<Equipment>();
			this.NbEquipmentCurent = 0;
			this._ramdom = new Random ();
		}
		// ----------------------------------------


		/**
		 * Calcule du nombre de point de defence
		 * 
		 * @return	int
		 */
		public int calculateNBPointDefence(){
			int countDefend = 0;
			foreach (Equipment oneEquipment in this.Equipments) {
				if (oneEquipment is IDefend) {
					countDefend++;
				}
			}
			return countDefend;
		}

		/**
		 * Calcule du poucentage de victoir
		 * 
		 * @return	Double	pourcentage victoir
		 */
		public double getPercentVictory()
		{
			int nbVictory = this.GladiatorWinNumber;
			int nbDefeat = this.GladiatorDefeatNumber;
			int NbMatchToPlay = nbVictory + nbDefeat;

			return (double)nbVictory*(double)100/(double)NbMatchToPlay;
		}

		/**
		 * Ajouter un equipement à sa liste d'equipement
		 * Avec test sur le nombre de points de équipments
		 * 
		 * @param	Equipment unEquipement
		 */
		public void addEquipment(Equipment onEquipment)
		{
			int nbPointEquipment = onEquipment.Point;

			if ((nbPointEquipment + this.NbEquipmentCurent) <= NB_MAX_EQUIPMENT) {
				this.Equipments.Add (onEquipment);
				this.NbEquipmentCurent = this.NbEquipmentCurent + nbPointEquipment;
				if (onEquipment is IDefend) {
					this.NbPointDefence++;
				}
			} else {
				int reste = NB_MAX_EQUIPMENT - this.NbEquipmentCurent ;
				Alert.showAlert ("Il reste " + reste.ToString() + " point(s) d'équipement au gladiateur !");
			}

		}

		/**
		 * divise par 2 tous les pourcentage de chance des equipements du gladiateur
		 * 
		 * 
		 */
		public void downDamage()
		{
			foreach (Equipment onEquipement in this.Equipments) {
				if (onEquipement is IAttack) {
					onEquipement.LuckyTouch = onEquipement.LuckyTouch / 2;
				}
			}
		}

		/**
		 *	Réarme le gladiteur : Remet les equipement.use à false.
		 *
		 */
		public void rearmament(){

			foreach (Equipment onEquipement in this.Equipments) {
				if (onEquipement is IAttack) {
					onEquipement.Use = false;
				}
			}

		}

		/**
		 * Renvois une arme au moment de l'attaque
		 * Avec ordre d'initiative des armes (Filet - Lance - Trident - Épée - Dague
		 *
		 * @return	int	chance de toucher l'adversaire
		 */
		public Equipment attack()
		{

			int nbEquipment = 0;
			Equipment e = null;

			// rechercher les equipements le plus fort
			foreach(Equipment onEquiment in this.Equipments){
				// Teste su l'équipement n'a pas déjà été utilisé
				if (!onEquiment.Use) {
					if (nbEquipment < onEquiment.Priority) {
						nbEquipment = onEquiment.Priority;
					}
				}

			}

			// mettre l'équipement trouver a true (pour ne pas le réutiliser)
			foreach(Equipment onEquiment in this.Equipments){
			
				if (onEquiment is IAttack && onEquiment.Priority == nbEquipment) {
					e = onEquiment;
				}
			}
			return e;

		}


		/**
		 * Renvois un true or false si le gladiateur est mort
		 *
		 * @param	Equipment		Chance que l'arme à de toucher l'adversaire;
		 * @return	void	pour voir si le gladiateur est tuer
		 */
		public void defend(Equipment p_equipment)
		{
			int i = 0;
			int countDefend = this.NbPointDefence;
			int touch = 0;

			if (p_equipment != null) {

			// Attack autent de fois que l'arme à de chance de toucher
				while(i <= (p_equipment.LuckyTouch/10)){

					Alert.showAlert (this.GladiatorName + " est loupé ! " );

					// Random pour le toucher
					int myNbRandom = _ramdom.Next (0, 10);

					// si le gladiateur est touché
					if (myNbRandom >= 5) {

						Alert.showAlert (this.GladiatorName + " est visé");
					
						// Protection
						foreach (Equipment onEquiment in this.Equipments) {

							//si arme de protection
							if (onEquiment is IDefend && onEquiment.Use == false) {

								Alert.showAlert ("Parade avec " + onEquiment.Name + " !");
							
								myNbRandom = _ramdom.Next (0, 10);

								// test si le gladiateur n'a pas contré la parade
								if (myNbRandom >= 5) {
									Alert.showAlert (this.GladiatorName + " n'a pas bloqué l'attaque");

									// l'adversaire à ustilisé un filet
									if (p_equipment is Net) {
										// appliquer un domage au arme
										Alert.showAlert ("////" + this.GladiatorName + "// est empetré dans un fillet");
										this.downDamage ();
										break;
									} else {
										// sinon enlever de la vie au gladiateur
										onEquiment.Use = true;
										this.NbPointDefence--;
										touch++;
									}


								} else {
								Alert.showAlert (this.GladiatorName + " a bloqué l'attaque");
								break;
								}

							}

						}
						// quand le gladiateur est toucher on arrete la boucle
						i = (p_equipment.LuckyTouch / 10);
					}

					i++;
				}
			}

			Alert.showAlertWith ("Nombre de vies restantes", (countDefend-touch).ToString());

			if (touch >= countDefend) {
				Alert.showRedAlert (this.GladiatorName + " est mort ! ");
				this.InGame = false;
			} else {
				this.InGame = true;
			}

		}





	}
}

