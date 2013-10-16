using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Spear : Equipment, IAttack
	{

		private double _luckyTouch;

		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		public double LuckyTouch {
			get {
				return this._luckyTouch;
			}
			set {
				this._luckyTouch = value;
			}
		}

		#endregion

		public Spear ():base("Lance", 7)
		{
			this._luckyTouch = 0.5;
		}
	}
}

