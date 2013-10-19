using System;
using Equipments.Interfaces;

namespace Equipments.Defend
{
	public class SmallShield : Equipment, IDefend
	{

		public SmallShield ():base("Petit bouclier rond", 5)
		{
			this.LuckyParry = 20;
			this.Use = false;

		}
	}
}

