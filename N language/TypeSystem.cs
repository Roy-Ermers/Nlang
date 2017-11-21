using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nlang.Types;
namespace Nlang
{
	public class TypeSystem
	{
		private List<Type> Types = new List<Type>();
		public TypeSystem()
		{
			Types.Add(new Str());
			Types.Add(new Num());
			Types.Add(new Null());
			Types.Add(new Bool());
		}
		public bool TypeExist(string Typename)
		{
			return Types.Exists(x => x.TypeName == Typename);
		}
		public Type ResolveType(string Typename)
		{
			var result =Types.Find(x => x.TypeName == Typename);
			if (result == null)
				throw new NotImplementedException(Typename);
			if(result is Null)
			{
				throw new NotSupportedException(Typename);
			}
			else return result;
		}
	}
}
