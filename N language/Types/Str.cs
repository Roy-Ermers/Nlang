using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlang.Types
{
	class Str : Type
	{
		public override string TypeName
		{
			get
			{
				return "Str";
			}
		}
		public string Value;
	}
}
