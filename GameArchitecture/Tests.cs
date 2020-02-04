using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			List<Bullet_TT_762_25> tt = new List<Bullet_TT_762_25>(3);
			var kalash = new KalashClip(HandgunTTClipSizes.Clip10);
			var ttClip = new HandgunTTClip(tt);
			var gun = new HandgunTT(new HandgunTTClip(HandgunTTClipSizes.Clip10));
			Console.WriteLine(gun.Clip.ShootablesLeftInClip);
			//gun.Reload();
			Console.WriteLine(gun.Clip.ShootablesLeftInClip);
			Console.WriteLine(gun.Clip.Name);
			Console.WriteLine(gun.Name);
			Console.WriteLine(gun.Shoot());
			foreach (var typesOfShootable in gun.Clip.GetTypesOfShootables())
			{
				Console.WriteLine(typesOfShootable);
			}
			
		}
	}
}
