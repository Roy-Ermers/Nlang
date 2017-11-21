using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Nlang
{
	class Lexer
	{

		#region Constants
		const char LeftParenthesis = '(';
		const char RightParenthesis = ')';
		const char Comma = ',';
		const char NumericNegative = '-';
		const string functionKeyword = "FUNC ";
		const char Indentation = '\t';
		#endregion
		private string File;
		TypeSystem TS;
		public Lexer(string file)
		{
			File = file;
			TS = new TypeSystem();
		}
		public ScriptFile Parse()
		{
			ScriptFile result = new ScriptFile(Path.GetFileNameWithoutExtension(File));
			string[] Lines = System.IO.File.ReadAllLines(File);
			for (int i = 0; i < Lines.Length; i++)
			{
				try
				{
					int currentIndentation = Lines[i].LastIndexOf(Indentation) + 1;
					string Line = Lines[i].TrimStart('\t');
					//function Initializing
					if (Line.ToUpper().StartsWith(functionKeyword))
					{
						Line = Line.TrimStart(functionKeyword.ToArray().Union(functionKeyword.ToLower().ToArray()).ToArray());
						Line = Line.TrimStart();
						string functionName = Line.Substring(0, Line.IndexOf(LeftParenthesis));
						string[] argumentList = Line.Substring(Line.IndexOf(LeftParenthesis) + 1, Line.LastIndexOf(RightParenthesis) - Line.IndexOf(LeftParenthesis) - 1).Split(',');
						List<KeyValuePair<string, Type>> Arguments = new List<KeyValuePair<string, Type>>();
						foreach (string arg in argumentList)
						{
							var argument = arg.TrimStart(' ');
							if (!string.IsNullOrEmpty(argument))
							{
								KeyValuePair<string, Type> r = new KeyValuePair<string, Type>(argument.Split(' ')[1], TS.ResolveType(argument.Split(' ')[0]));
								Arguments.Add(r);
							}
						}
						string[] codeBlock = GetCodeBlock(currentIndentation, Lines.Skip(i + 1).ToArray());
						Function func = new Function(functionName, codeBlock, Arguments.ToArray());
						i += codeBlock.Length;
						result.Functions.Add(func);
					}
					//Global Variables
					else if (TS.TypeExist(Line.Trim('\t').Substring(0, Line.IndexOf(' '))))
					{
						Line = Line.Trim('\t');
						Variable Result = new Variable();
						Result.Type = TS.ResolveType(Line.Substring(0, Line.IndexOf(' ')));
						if (Line.Contains("="))
						{
							Result.Identifier = Line.Substring(Line.IndexOf(' '), Line.IndexOf('=') - Line.IndexOf(' ')).TrimEnd(' ');
							Result.Value = Line.Substring(Line.IndexOf('=') + 1).TrimStart(' ');
						}
						result.Variables.Add(Result);
					}
					else
					{
						throw new NException($"Type \"{Line.Trim('\t').Substring(0, Line.IndexOf(' '))}\" does not exist.", i,result.ClassName);
					}
				}
				catch(NotSupportedException NotSupported)
				{
					throw new NException(String.Format("Type \"{1}\" is not supported as variable type.", i, NotSupported.Message),i,result.ClassName);
				}
			}
			return result;

		}
		/// <summary>
		/// irritrates trough <paramref name="Lines"/> to return the correct codeblock
		/// </summary>
		/// <param name="Indentation"></param>
		/// <param name="Lines"></param>
		/// <param name="IndentChar"></param>
		/// <returns>The Codeblock</returns>
		private string[] GetCodeBlock(int Indentation, string[] Lines, char IndentChar = '\t')
		{
			int index = -1;
			foreach (string line in Lines.ToArray())
			{
				index++;
				int currentIndentation = Lines[index].LastIndexOf(IndentChar) + 1;
				if (currentIndentation <= Indentation)
					return Lines.Take(index).ToArray();
			}
			return Lines;
		}
	}
}
