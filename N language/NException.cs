using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlang
{
	class NException : Exception
	{
		public int Line;
		public string ClassName;
		public NException(string Message, int Line,string classname = "") : base(Message)
		{
			this.Line = Line;
			this.ClassName = classname;
		}
	}
}
