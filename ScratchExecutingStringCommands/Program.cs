// add NuGet package 'Microsoft.CodeAnalysis.Scripting'
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace ScratchExecutingStringCommands
{
	class Program
	{
        static void Main(string[] args)
        {
            try
            {
                //string exec = "System.Math.Pow(2, 4)";
                //var x = CSharpScript.EvaluateAsync(exec); // returns 16
                //Print(exec, x);

                //DSV Situation Test
                //Read the value from the XML
                //NB: NULL CHECKING!
                var sourcevalue = "Code - FinsurvId";
                if (sourcevalue == null) return;

                //from the json
                string action = "sourcevalue.Split('-')[1]";

                //replace the placeholder in the action with the actual value
                //remember the QUOTES!
                action = action.Replace("sourcevalue", "\"" + sourcevalue + "\"");

                //Execute the action against the sourcevalue
                //The result HAS to be string!
                Task<string> x = CSharpScript.EvaluateAsync<string>(action);
                //var Destinationelement - finsurvid element
                Print(action, x);

                //Multiline test
                sourcevalue = "multiply 2 3";
                //from the json
                action = "int first = Int32.Parse(sourcevalue.Split(' ')[1].Trim()); " +
                            "int second = Int32.Parse(sourcevalue.Split(' ')[2].Trim());" +
                            "return (first * second).ToString();";

                //replace the placeholder in the action with the actual value
                //remember the QUOTES!
                action = action.Replace("sourcevalue", "\"" + sourcevalue + "\"");

                //Execute the action against the sourcevalue
                //The result HAS to be string!
                x = CSharpScript.EvaluateAsync<string>(action, ScriptOptions.Default.WithImports("System"));
                //var Destinationelement - finsurvid element
                Print(action, x);
            }
            catch (CompilationErrorException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Join(Environment.NewLine, e.Diagnostics));
            }
            Console.ResetColor();
            Console.ReadLine();
        }

        private static void Print(string exec, Task<string> x)
        {
            var result = "NULL";
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (x.Result != null)
            {
                result = x.Result;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"[{exec}] resulted in [{result.Trim()}]");
        }
    }
}
