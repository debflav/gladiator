using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Net : Equipment, IAttack
	{

		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		#endregion

		public Net ():base("Filet", 3)
		{
			this.LuckyTouch = 30;
			this.Priority = 5;
			this.Use = true;
		}
	}
}

