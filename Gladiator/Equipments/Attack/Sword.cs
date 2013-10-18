using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Sword : Equipment, IAttack
	{

		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		#endregion

		public Sword ():base("Épée", 5)
		{
			this.LuckyTouch = 70;
			this.Priority = 2;
			this.Use = false;
		}
	}
}

