using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Spear : Equipment, IAttack
	{


		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		#endregion

		public Spear ():base("Lance", 7)
		{
			this.LuckyTouch = 50;
			this.Priority = 4;
			this.Use = false;
		}
	}
}

