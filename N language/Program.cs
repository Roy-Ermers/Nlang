using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Nlang
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length >= 1)
			{
				Lexer lexer;
				if (File.Exists(args[0]))
				{
					lexer = new Lexer(args[0]);
					lexer.Parse();
				}
				else if (Directory.Exists(args[0]))
				{
					if (File.Exists(Path.Combine(args[0], "Program.n"))) {
						lexer = new Lexer(Path.Combine(args[0], "program.n"));
						try
						{
							var program = lexer.Parse();
							program.ExecuteFunction("Init");
						}
						catch(NException Ne)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine($"{Ne.ClassName}-{Ne.Line}: {Ne.Message}");
							Console.ResetColor();
							Console.ReadKey();
						} 
					}
					else {
						throw new FileNotFoundException("","program.n");
					}
				}
			}
			else
			{
				throw new FileNotFoundException("You need to specify a folder or file.");
			}
		}
	}
}
