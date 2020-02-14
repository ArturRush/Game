using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items
{
	/// <summary>
	/// thing that can be shoted from IShooter weapon
	/// </summary>
	public interface IShootable
	{
		float ShootableDamage { get; }
	}
}
