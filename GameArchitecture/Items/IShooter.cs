﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items
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

		/// <summary>
		///  How many 'bullets' can be shooted at once (1 for handgun, inf for automatic riffle)
		/// </summary>
		int FiringModeQuantity { get; }

		event Action<IShooter> OnShootStart;
		event Action<IShooter, IShootable> OnShoot;
		event Action<IShooter> OnShootEnd;

		void ShootStart();
		IShootable Shoot();
		void ShootEnd();
	}
}