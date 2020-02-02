using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	//thing that can be shoted from IShoot weapon
	interface IShootable
	{
		float ShootableDamage { get; set; }
	}
}
