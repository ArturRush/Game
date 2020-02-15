using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture;
using GameArchitecture.Items;
using GameArchitecture.Items.Weapons;

namespace TestEnv
{
	public class Test
	{
		public static void RunTests()
		{
			GunBullet b = new GunBullet("BULLETNAME", "fdfd", 4);
			GunBullet bb = new GunBullet("BB", "fdfd", 4);
			GunClip c = new GunClip("C10", "ddddd", 10, new List<string>() {"BULLETNAME", "B"});
			VampireGun g = new VampireGun("GUNNAME", "DFDF", 1, 2, 50, 1, new List<string>() {"C8", "C10"});
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
			g.Shoot();
			Console.WriteLine(g.BulletsLeft());
		}

		private static void G_OnShoot(IShooter gun, IShootable bullet)
		{
			Console.WriteLine(((GunWithClip) gun).Name);
			Console.WriteLine(((GunBullet) bullet).Name);
		}
	}
}