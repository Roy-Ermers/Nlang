using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlang
{
	class Function
	{
		private string functionName;

		public string FunctionName
		{
			get
			{
				return functionName;
			}
		}
		private string[] Lines;
		public Dictionary<string, Type> Arguments;
		public Function(string FunctionName)
		{
			functionName = FunctionName;
		}
		public Function(string FunctionName, string[] lines)
		{
			functionName = FunctionName;
			Lines = lines;
		}
		public Function(string FunctionName, string[] lines, params KeyValuePair<string,Type>[] arguments)
		{
			functionName = FunctionName;
			Lines = lines;
			Arguments = arguments.ToDictionary(x=>x.Key,x=>x.Value);
		}
	}
}
