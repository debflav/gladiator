using System;
using Equipments;
using Equipments.Interfaces;

namespace Equipments.DefendAndAtack
{
	public class Trident : Equipment, IAttack, IDefend
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

		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		#endregion


		public Trident ():base("Tridant", 7)
		{
			this.LuckyParry = 0.1;
			this.LuckyTouch = 40;
			this.Priority = 3;
		}

	}
}

