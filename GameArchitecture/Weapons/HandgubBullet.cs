using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	// gun bullet - can be shooted
	class HandgubBullet : GunShell, IShootable
	{
		public float ShootableDamage { get; set; }

		public HandgubBullet(float shootableDamage)
		{
			ShootableDamage = shootableDamage;
		}
	}
}
