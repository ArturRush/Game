using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items.Weapons
{
	public class MeleeWeapon: INamable, IMelee, ISpecial
	{
		public string Name { get; }
		public string Description { get; }
		public float MeleeDamage { get; }
		public float MeleeRange { get; }
		private Action<object, object> specialAction;

		public MeleeWeapon(string name, string description, float meleeDamage, float meleeRange, Action<object, object> specialAction)
		{
			Name = name;
			Description = description;
			MeleeDamage = meleeDamage;
			MeleeRange = meleeRange;
			this.specialAction = specialAction;
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

		public void SpecialAction(object actor, object target)
		{
			specialAction(actor, target);
		}
	}
}
