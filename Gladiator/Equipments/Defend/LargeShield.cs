using System;
using Equipments.Interfaces;

namespace Equipments.Defend
{
	public class LargeShield : Equipment, IDefend
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

		public LargeShield ():base("Bouclier rectangulaire", 8)
		{
			this.LuckyParry = 0.3;
		}
	}
}

