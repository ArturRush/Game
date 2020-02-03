using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	// For the weapon that can shoot
	public interface IShooter
	{
		float ShootDamage { get; set; }
		float ShootRange { get; set; }
		
		//Seconds
		float ReloadTime { get; set; }

		//Размер обоймы
		float ClipSize { get; set; }

		// How many 'bullets' can be shooted at once (1 for handgun, inf for automatic riffle)
		int FiringModeQuantity { get; set; }

		void ShootStart();
		void Shoot();
		void ShootEnd();
	}
}