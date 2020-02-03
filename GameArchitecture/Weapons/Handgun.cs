using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	public class Handgun: Item, IShooter, IThrowable, IMelee
	{
		private int firingModeQuantity = 1;
		public int FiringModeQuantity
		{
			get => firingModeQuantity;
			set => firingModeQuantity = 1;
		}

		public float ShootDamage { get; set; }
		public float ShootRange { get; set; }
		public float ReloadTime { get; set; }
		public float ClipSize { get; set; }
		public float ThrowDamage { get; set; }
		public float MeleeDamage { get; set; }
		public float MeleeRange { get; set; }

		public void ShootStart()
		{

		}

		public void Shoot()
		{
		}

		public void ShootEnd()
		{
		}

		public void AttackStart()
		{
		}

		public void Attack()
		{
		}

		public void AttackEnd()
		{
		}
	}
}
