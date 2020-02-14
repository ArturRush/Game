using GameArchitecture.Items;

namespace GameArchitecture.Items.Weapons
{
	/// <summary>
	/// gun bullet - can be shooted
	/// </summary>
	public class GunBullet : IShootable, INamable
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public float ShootableDamage { get; protected set; }

		public GunBullet(string name, string description, float shootableDamage)
		{
			Name = name;
			Description = description;
			ShootableDamage = shootableDamage;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
