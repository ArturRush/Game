using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture
{
	public interface INamable
	{
		String Name { get; }
		String Description { get; }

		//TODO приведение к строке
	}
}