using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Weapons.Bullets;

namespace GameArchitecture.Weapons
{
	public abstract class Handgun : INamable, IShooter, IThrowable, IMelee
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public int FiringModeQuantity { get; protected set; }
		public float ShootDamage { get; protected set; }
		public float ShootRange { get; protected set; }
		public float ReloadTime { get; protected set; }
		public GunClip Clip { get; protected set; }
		public float ThrowDamage { get; protected set; }
		public float MeleeDamage { get; protected set; }
		public float MeleeRange { get; protected set; }

		public virtual void ShootStart()
		{
			Shoot();
		}

		public virtual bool Shoot()
		{
			return Clip.Shoot();
		}

		public virtual void ShootEnd()
		{
		}

		public void Reload(GunClip clip)
		{
			TakeOutClip();
			PutClip(clip);
		}

		private void TakeOutClip()
		{
			Clip = null;
		}

		private void PutClip(GunClip clip)
		{
			Clip = clip;
		}

		public virtual void AttackStart()
		{
		}

		public virtual void Attack()
		{
		}

		public virtual void AttackEnd()
		{
		}
	}
}