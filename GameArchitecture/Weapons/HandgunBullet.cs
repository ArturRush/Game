using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	// gun bullet - can be shooted
	public abstract class HandgunBullet : IShootable, INamable
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public float ShootableDamage { get; protected set; }
	}
}
