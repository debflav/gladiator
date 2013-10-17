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


		public Trident ():base("Tridant", 7)
		{
			this.LuckyParry = 0.1;
			this.LuckyTouch = 0.4;
		}

	}
}

