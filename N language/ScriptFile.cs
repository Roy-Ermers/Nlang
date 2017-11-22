using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlang
{
	class ScriptFile
	{
		public List<Function> Functions;
		public List<Variable> Variables;
		public string ClassName { get; private set; }
		public ScriptFile(string ClassName)
		{
			this.ClassName = ClassName;
			Functions = new List<Function>();
			Variables = new List<Variable>();
		}
		public void ExecuteFunction(string FunctionName,params KeyValuePair<string,Type>[] Args)
		{
			Functions.Find(x=>x.FunctionName==FunctionName)
		}
	}
}
