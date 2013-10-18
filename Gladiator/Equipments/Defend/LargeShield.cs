using System;
using Equipments.Interfaces;

namespace Equipments.Defend
{
	public class LargeShield : Equipment, IDefend
	{

		public LargeShield ():base("Bouclier rectangulaire", 8)
		{
			this.LuckyParry = 30;
			this.Use = false;
		}
	}
}

