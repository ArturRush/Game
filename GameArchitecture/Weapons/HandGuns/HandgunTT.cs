using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Weapons.Bullets;

namespace GameArchitecture.Weapons.HandGuns
{
	class HandgunTT : GunWithClip
	{
		public HandgunTT(IClipTT clip)
		{
			Name = "TT";
			Description = "Handgun Tulsky Tokarev";
			FiringModeQuantity = 1;
			ShootDamage = 10;
			ShootRange = 50;
			ReloadTime = 0.8f;
			Clip = (GunClip) clip;
			ThrowDamage = 1;
			MeleeDamage = 1;
			MeleeRange = 1;
		}

		public override void Reload(GunClip clip)
		{
			if (clip is IClipTT)
			{
				base.Reload(clip);
				return;
			}
			Console.WriteLine("This clip can not be attached to this gun");
		}

		public override void PutClip(GunClip clip)
		{
			if (this.Clip != null)
			{
				Console.WriteLine("Clip is already in the gun");
				return;
			}
			if (clip is IClipTT)
			{
				base.PutClip(clip);
				return;
			}
			Console.WriteLine("This clip can not be attached to this gun");
		}
	}

	class HandgunTTClip : GunClip, IClipTT
	{
		public HandgunTTClip(HandgunTTClipSizes clipModel)
		{
			Name = $"TT clip {(int) clipModel}";
			Description = $"Clip for TT for {(int) clipModel} bullets";
			ThrowDamage = 1;
			ClipSize = (int) clipModel;
		}

		/// <summary>
		/// Charge clip with list of shootables
		/// </summary>
		/// <param name="shootables"></param>
		/// <returns>List of shootables, which was;n charged</returns>
		public List<IShootable> ChargeClip(List<IShootable> shootables)
		{
			List<IShootable> notCharged = new List<IShootable>();
			foreach (var shootable in shootables)
			{
				if(!ChargeClip(shootable))
					notCharged.Add(shootable);
			}
			return notCharged;
		}

		/// <summary>
		/// Charge one shootable to clip
		/// </summary>
		/// <param name="shootable"></param>
		/// <returns>Was charged - true</returns>
		public override bool ChargeClip(IShootable shootable)
		{
			if (shootable is IBullet_TT)
				return base.ChargeClip(shootable);
			Console.WriteLine("Bullet of type {0} cannot be charged to clip type {1}", shootable, this);
			return false;
		}
	}

	class KalashClip : GunClip
	{
		public KalashClip(int bulletNum)
		{
			Name = $"Kalash clip {bulletNum}";
			Description = $"Clip for TT for {bulletNum} bullets";
			ThrowDamage = 1;
			ClipSize = bulletNum;
		}
	}

	public interface IClipTT
	{
	}

	enum HandgunTTClipSizes
	{
		Clip8 = 8,
		Clip10 = 10,
		Clip14 = 14,
		Clip16 = 16,
	}
}