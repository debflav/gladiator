using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Dagger : Equipment, IAttack
	{

		#region IAttack implementation

		public void downDamage ()
		{
			this.LuckyTouch = this.LuckyTouch / 2;
		}

		#endregion

		public Dagger ():base("Dague", 2)
		{
			this.LuckyTouch = 60;
			this.Priority = 1;
			this.Use = true;
		}


	}
}

