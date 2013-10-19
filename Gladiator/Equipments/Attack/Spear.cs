using System;
using Equipments.Interfaces;

namespace Equipments.Attack
{
	public class Spear : Equipment, IAttack
	{

		public Spear ():base("Lance", 7)
		{
			this.LuckyTouch = 50;
			this.Priority = 4;
			this.Use = false;
		}
	}
}

