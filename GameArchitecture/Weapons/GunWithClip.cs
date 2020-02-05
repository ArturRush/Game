using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Weapons.Bullets;

namespace GameArchitecture.Weapons
{
	public abstract class GunWithClip : INamable, IShooter, IThrowable, IMelee
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public int FiringModeQuantity { get; protected set; }
		public float ShootDamage { get; protected set; }
		public float ShootRange { get; protected set; }
		public float ReloadTime { get; protected set; }
		//TODO limit access to Clip from Gun
		public GunClip Clip { get; protected set; }
		public float ThrowDamage { get; protected set; }
		public float MeleeDamage { get; protected set; }
		public float MeleeRange { get; protected set; }

		public virtual void ShootStart()
		{
			Shoot();
		}

		public virtual IShootable Shoot()
		{
			if (Clip == null)
				return null;
			return Clip.Shoot();
		}

		public virtual void ShootEnd()
		{
		}

		public virtual void Reload(GunClip clip)
		{
			TakeOutClip();
			PutClip(clip);
		}

		public virtual GunClip TakeOutClip()
		{
			var res = Clip;
			Clip = null;
			return res;
		}

		public virtual void PutClip(GunClip clip)
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

		public virtual int BulletsLeft()
		{
			if (Clip == null) return 0;
			return Clip.ShootablesLeftInClip;
		}

		public virtual string ClipName()
		{
			if (Clip == null) return "No clip in gun";
			return Clip.Name;
		}

		public virtual string ClipDescription()
		{
			if (Clip == null) return "No clip in gun";
			return Clip.Description;
		}

		public virtual List<string> GetShootablesInClip()
		{
			var res = new List<string>();

			if (Clip == null) return res;
			res = Clip.GetTypesOfShootables().Select(x=>x.ToString()).ToList();

			return res;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}