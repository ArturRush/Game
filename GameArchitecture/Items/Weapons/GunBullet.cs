using System;
using GameArchitecture.Items;

namespace GameArchitecture.Items.Weapons
{
	/// <summary>
	/// gun bullet - can be shooted
	/// </summary>
	public class GunBullet : IShootable, INamable, ISpecial
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public float ShootableDamage { get; protected set; }
		private Action<object, object> specialAction;

		public GunBullet(string name, string description, float shootableDamage, Action<object,object> specialAction)
		{
			Name = name;
			Description = description;
			ShootableDamage = shootableDamage;
			this.specialAction = specialAction;
		}

		public override string ToString()
		{
			return Name;
		}

		public void SpecialAction(object actor, object target)
		{
			specialAction(actor, target);
		}
	}
}
