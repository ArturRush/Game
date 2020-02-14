using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items
{
	//Can be thrown for attack (bomb, stone, snowball)
	interface IThrowable
	{
		float ThrowDamage { get;  }
	}
}
