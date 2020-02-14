namespace GameArchitecture.Items
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