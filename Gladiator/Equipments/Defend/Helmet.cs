using System;
using Equipments.Interfaces;

namespace Equipments.Defend
{
	public class Helmet : Equipment, IDefend
	{
		private double _luckyParry;

		#region IDefend implementation
		public float LuckyParry {
			get {
				return this._luckyParry;
			}
			set {
				this._luckyParry = value;
			}
		}
		#endregion

		public Helmet ():base("Casque", 2)
		{
			this.LuckyParry = 0.1;
		}

	}
}

