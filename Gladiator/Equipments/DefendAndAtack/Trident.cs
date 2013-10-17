using System;
using Equipments;
using Equipments.Interfaces;

namespace Equipments.DefendAndAtack
{
	public class Trident : Equipment, IAttack, IDefend
	{

		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		#endregion


		public Trident ():base("Tridant", 7)
		{
			this.LuckyParry = 10;
			this.LuckyTouch = 40;
			this.Priority = 3;
		}

	}
}

