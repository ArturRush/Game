using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	interface IThrower
	{
		float ThrowDamage { get; set; }
		float ThrowRange { get; set; }
	}
}
