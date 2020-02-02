using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	//Example - handgun. It is a weapon, that can shoot, can be melee and can be thrown.
	class Handgun : Weapon, IShoot, IThrowable
	{
		public float ShootDamage { get; set; }
		public float ThrowDamage { get; set; }

		public Handgun(float shootDamage, float throwDamage)
		{
			ShootDamage = shootDamage;
			ThrowDamage = throwDamage;
		}

		public override void Attack()
		{
			base.Attack();

		}
	}
}
