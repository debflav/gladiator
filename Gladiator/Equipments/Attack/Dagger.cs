using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Dagger : Equipment, IAttack
	{
	
		public Dagger ():base("Dague", 2)
		{
			this.LuckyTouch = 60;
			this.Priority = 1;
			this.Use = false;
		}


	}
}

