using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons.Handguns
{
	public class Handgun: IShoot, IThrowable, IMelee
	{
		public float ShootDamage { get; set; }
		public float ShootRange { get; set; }
		public float ReloadTime { get; set; }
		public float ClipSize { get; set; }
		public int FiringModeQuantity { get; set; }
		public float ThrowDamage { get; set; }
		public float MeleeDamage { get; set; }
		public float MeleeRange { get; set; }


	}
}
