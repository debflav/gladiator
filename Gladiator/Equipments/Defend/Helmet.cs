using System;
using Equipments.Interfaces;

namespace Equipments.Defend
{
	public class Helmet : Equipment, IDefend
	{
	
		public Helmet ():base("Casque", 2)
		{
			this.LuckyParry = 10;
			this.Use = true;
		}

	}
}

