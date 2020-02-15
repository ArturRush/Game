using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items.Weapons
{
	public class MeleeWeapon: INamable, IMelee
	{
		public string Name { get; }
		public string Description { get; }
		public float MeleeDamage { get; }
		public float MeleeRange { get; }

		public MeleeWeapon(string name, string description, float meleeDamage, float meleeRange)
		{
			Name = name;
			Description = description;
			MeleeDamage = meleeDamage;
			MeleeRange = meleeRange;
		}

		public void AttackStart()
		{
			throw new NotImplementedException();
		}

		public void Attack()
		{
			throw new NotImplementedException();
		}

		public void AttackEnd()
		{
			throw new NotImplementedException();
		}
	}
}
