using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons.Bullets
{
	public class Bullet_TT_762_25: GunBullet, IBullet_TT
	{
		public Bullet_TT_762_25()
		{
			Name = "TT 7,62x25mm";
			Description = "Bullet for handgun TT, 7,62x25mm";
			ShootableDamage = 2;
		}
	}

	public interface IBullet_TT { }
}
