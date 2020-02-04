using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Weapons.Bullets;

namespace GameArchitecture.Weapons.HandGuns
{
	class HandgunTT : Handgun
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
	}

	class HandgunTTClip : GunClip, IClipTT
	{
		public HandgunTTClip(HandgunTTClipSizes clipModel)
		{
			Name = "TT clip 8";
			Description = "Clip for TT for 8 bullets";
			ThrowDamage = 1;
			ClipSize = (int) clipModel;
		}

		public HandgunTTClip(List<IShootable> shootables)
		{
			foreach (var shootable in shootables)
			{
				ChargeClip(shootable);
			}
		}

		public override bool ChargeClip(IShootable shootable)
		{
			try
			{
				var tt_bullet = (IBullet_TT) shootable;
				return base.ChargeClip(shootable);
			}
			catch
			{
				Console.WriteLine("Bullet of type {0} cannot be charged to clip type {1}", shootable.GetType(), this.GetType());
				return false;
			}
		}
	}

	class KalashClip : GunClip
	{
		public KalashClip(HandgunTTClipSizes clipModel)
		{
			Name = "TT clip 8";
			Description = "Clip for TT for 8 bullets";
			ThrowDamage = 1;
			ClipSize = (int)clipModel;
		}
	}

	public interface IClipTT{}

	enum HandgunTTClipSizes
	{
		Clip8 = 8,
		Clip10 = 10,
		Clip14 = 14,
		Clip16 = 16,
	}
}