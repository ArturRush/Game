﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Items
{
	public interface ISpecial
	{
		void SpecialEffect(object actor, object target);
	}
}