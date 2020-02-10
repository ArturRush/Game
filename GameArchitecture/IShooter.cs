using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Weapons;

namespace GameArchitecture
{
	/// <summary>
	/// For the things that can shoot.
	/// First implement abstract class - handgun, riffle...
	/// Then implement type of your weapon
	/// </summary>
	public interface IShooter
	{
		float ShootDamage { get; }
		float ShootRange { get;  }

		//Seconds
		float ReloadTime { get; }
		
		// How many 'bullets' can be shooted at once (1 for handgun, inf for automatic riffle)
		int FiringModeQuantity { get; }

		event Action OnShootStart;
		event Action OnShoot;
		event Action OnShootEnd;

		void ShootStart();
		IShootable Shoot();
		void ShootEnd();
	}
}