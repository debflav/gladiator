using System;

namespace Equipments.Interfaces
{
	public interface IAttack
	{

		double LuckyTouch{ get; set;}

		// Fonction pour réduire la puissance des coups
		void downDamage ();

	}
}

