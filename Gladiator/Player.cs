using System;

namespace Gladiator
{
	public class Player
	{
		private string _name;
		public string Name {
			get { return this._name; }
			set { this._name = value; }
		}

		private string _prenom;
		public string Prenom {
			get { return this._prenom; }
			set { this._prenom = value; }
		}



		public Player ()
		{
		}
	}
}

