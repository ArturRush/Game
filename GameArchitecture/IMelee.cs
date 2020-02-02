using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	// For the weapon that can be used as a melee weapon
	interface IMelee
	{
		float MeleeDamage { get; set; }
		float MeleeRange { get; set; }
	}
}