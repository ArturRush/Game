using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons.GunShells
{
	// gun bullet - can be shooted
	class HandgunBullet : IShootable
	{
		public float ShootableDamage { get; set; }

		public HandgunBullet(float shootableDamage)
		{
			ShootableDamage = shootableDamage;
		}
	}
}
