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
			} else {
				int reste = NB_MAX_EQUIPMENT - this.NbEquipmentCurent ;
				Alert.showAlert ("Vous avez dépassé la limite de " + reste.ToString() + " point(s) d'équipement au gladiateur: " + this.GladiatorName);
			}

		}


		/**
		 * Renvois une arme au moment de l'attaque
		 * Avec ordre d'initiative des armes (Filet - Lance - Trident - Épée - Dague
		 * 
		 * @param	bool false si premier passe d'arme true si Attack réel
		 * @return	int	chance de toucher l'adversaire
		 */
		public Equipment attack(bool gauge)
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
					if (gauge) {
						onEquiment.Use = true;
					}
					e = onEquiment;
				}
			}

			if (e != null) {
				Alert.showAlertWith ("arme selectionné", e.Name);
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
			int countDefend = 0;
			int touch = 0;

			//Alert.showAlertWith ("defend", p_equipment.Name);

			// Compte le nombre de protection;
			foreach (Equipment oneEquipment in this.Equipments) {
			
				if (oneEquipment is IDefend) {
					countDefend++;
				}
				
			}

			if (p_equipment != null) {


				while(i <= (p_equipment.LuckyTouch/10)){

					Alert.showAlertWith ("gladiator defender", this.GladiatorName);

					// Random pour le toucher
					RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider ();
					byte[] data = new byte[4];
					rng.GetBytes (data);
					int value = BitConverter.ToInt32(data, 0);

					int myNbRandom = value / 10000000;

					// si le gladiateur est touché
					if (myNbRandom >= 50) {

						//Alert.showAlertWith ("dans le if", i.ToString());

						// Protection
						foreach (Equipment onEquiment in this.Equipments) {
							//si arme de protection
							if (onEquiment is IDefend && onEquiment.Use == false) {
								//protection chance de protection
								for(int j = 0; j<= onEquiment.LuckyParry/10; j++){

									// Random pour le toucher
									RNGCryptoServiceProvider rng2 = new RNGCryptoServiceProvider ();
									byte[] data2 = new byte[4];
									rng2.GetBytes (data2);
									int value2 = BitConverter.ToInt32(data, 0);

									int myNbRandom2 = value2 / 10000000;

									if (myNbRandom2 >= 50) {
										onEquiment.Use = true;
										touch++;

									}
								}

							}

						}

						// quand le gladiateur est toucher on arrete la boucle
						i = p_equipment.LuckyTouch / 10;

					}
					i++;
				}
			}

			Alert.showAlertWith ("touch", touch.ToString ());
			Alert.showAlertWith ("countDefend", countDefend.ToString ());

			if (touch < countDefend) {
				this.InGame = true;
			} else {
				this.InGame = false;
			}

		}





	}
}

