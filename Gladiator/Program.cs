using System;
using Equipments;
using Equipments.Attack;
using Equipments.Defend;
using Equipments.Interfaces;

namespace Gladiator
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Dagger maDague = new Dagger();
			Net MonFilet = new Net();
			Spear MaLance = new Spear ();
			Sword monEpee = new Sword ();
			Console.WriteLine (maDague.Name);
			Console.WriteLine (MonFilet.Name);
			Console.WriteLine (MaLance.Name);
			Console.WriteLine (monEpee.Name);

		}
	}
}
