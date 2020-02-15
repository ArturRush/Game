using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Items;
using GameArchitecture.Items.Weapons;

namespace TestEnv
{
	public class VampireGun:GunWithClip
	{
		public VampireGun(string name, string description, int firingModeQuantity, float shootDamage, float shootRange, float reloadTime, List<string> compatibleClips) : base(name, description, firingModeQuantity, shootDamage, shootRange, reloadTime, compatibleClips)
		{
		}

		public new IShootable Shoot()
		{
			Console.WriteLine("Target's life stealed");
			return base.Shoot();
		}
	}
}
