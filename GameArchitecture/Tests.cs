using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameArchitecture.Weapons;

namespace GameArchitecture
{
	public static class Tests
	{
		public static void RunTest()
		{
			GunBullet b = new GunBullet("B", "fdfd", 4);
			GunBullet bb = new GunBullet("BB", "fdfd", 4);
			GunClip c = new GunClip("C10","dddd",10,new List<string>(){"A","B"});
			GunWithClip g = new GunWithClip("G","DFDF",1,2,50,1,new List<string>(){"C8","C10"});
			g.OnShoot += G_OnShoot;

			g.PutClip(c);
			Console.WriteLine(g.Shoot());
			var clip = g.TakeOutClip();
			clip.ChargeClip(bb);
			var bullets = new List<IShootable>();
			for (int i = 0; i < 5; i++)
			{
				bullets.Add(b);
			}
			clip.ChargeClip(bullets);
			g.PutClip(clip);

			Console.WriteLine(g.BulletsLeft());
			Console.WriteLine(g.Shoot());
			Console.WriteLine(g.BulletsLeft());
		}

		private static void G_OnShoot()
		{
			Console.WriteLine("Something shooted");
		}
	}
}