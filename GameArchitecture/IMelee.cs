using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	// For the weapon that can be used as a melee weapon
	public interface IMelee
	{
		float MeleeDamage { get;  }
		float MeleeRange { get;  }

		void AttackStart();
		void Attack();
		void AttackEnd();

	}
}