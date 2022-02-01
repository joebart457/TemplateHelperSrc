using Mochj.Models.Fn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Frontend.Services
{
    static class ScriptingService
    {

        public static void AddGlobalFunction(string name, Function fn)
        {
            Mochj.Builders.DefaultEnvironmentBuilder.Default.Define(name, Mochj.Builders.QualifiedObjectBuilder.BuildFunction(fn), true);
        }

        public static void RunInSandbox(string code)
        {

            var interpreter = new Mochj._Interpreter.Interpreter(Mochj.Builders.DefaultEnvironmentBuilder.Default);
            var parser = new Mochj._Parser.Parser();
            var tokenizer = Mochj.Builders.DefaultTokenizerBuilder.Build();
            interpreter.Accept(parser.Parse(tokenizer.Tokenize(code)));
        }
    }
}
