using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	// For the weapon that can shoot
	interface IShoot
	{
		float ShootDamage { get; set; }
	}
}
