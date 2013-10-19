using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Net : Equipment, IAttack
	{
	
		public Net ():base("Filet", 3)
		{
			this.LuckyTouch = 30;
			this.Priority = 5;
			this.Use = false;
		}
	}
}

