﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items
{
	public interface INamable
	{
		string Name { get; }
		string Description { get; }
	}
}