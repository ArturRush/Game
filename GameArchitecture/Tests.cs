using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameArchitecture.Weapons;
using GameArchitecture.Weapons.Bullets;
using GameArchitecture.Weapons.HandGuns;

namespace GameArchitecture
{
	public static class Tests
	{
		public static void RunTest()
		{
			List<Bullet_TT_762_25> tt =
				new List<Bullet_TT_762_25>() {new Bullet_TT_762_25(), new Bullet_TT_762_25(), new Bullet_TT_762_25()};
			var kalash = new KalashClip(30);
			var ttClip = new HandgunTTClip(HandgunTTClipSizes.Clip14);
			ttClip.ChargeClip(new List<IShootable>(tt));
			var gun = new HandgunTT(ttClip);
			Console.WriteLine(gun.BulletsLeft());
			gun.Reload(kalash);
			gun.TakeOutClip();
			gun.PutClip(ttClip);
			Console.WriteLine(gun.BulletsLeft());
			Console.WriteLine(gun.ClipName());
			Console.WriteLine(gun.Name);
			Console.WriteLine(gun.Shoot());
			foreach (var typesOfShootable in gun.GetShootablesInClip())
			{
				Console.WriteLine(typesOfShootable);
			}
		}
	}
}