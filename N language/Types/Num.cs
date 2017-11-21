using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlang.Types
{
	class Num :Type
	{
		public int Value { get; set; }

		public override string TypeName
		{
			get
			{
				return "Num";
			}
		}
	}
}
