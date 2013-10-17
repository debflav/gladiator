using System;
using Equipments.Interfaces;

namespace Equipments.Defend
{
	public class SmallShield : Equipment, IDefend
	{

		private double _luckyParry;

		#region IDefend implementation
		public double LuckyParry {
			get {
				return this._luckyParry;
			}
			set {
				this._luckyParry = value;
			}
		}
		#endregion

		public SmallShield ():base("Petit bouclier rond", 5)
		{
			this.LuckyParry = 0.1;
		}
	}
}

