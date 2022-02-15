using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Mochj.Builders;
using Mochj.Models.Fn;
using Template.ExampleLib;

namespace ExportItems
{
    public class Export
    {
        public int Setup(Mochj._Storage.Environment environment)
        {
            Mochj._Storage.Environment sqlNamespace = new Mochj._Storage.Environment(null);


            sqlNamespace.Define("generate-entity",
              QualifiedObjectBuilder.BuildFunction(
                  new NativeFunction()
                  .Action((Args args) =>
                  {
                      try
                      {
                          string filepath = args.Get<string>(0);

                          var reader = new StringReader(File.ReadAllText(filepath));
                          IList<ParseError> errors = null;
                          var parser = new TSql150Parser(true, SqlEngineType.All);

                          var tree = parser.Parse(reader, out errors);

                          SqlTableCreatorVisitor visitor = new SqlTableCreatorVisitor();
                          tree.Accept(visitor);

                          StringBuilder sb = new StringBuilder();
                          foreach (var tableDefinition in visitor.TableDefinitions)
                          {
                              sb.Append(tableDefinition);
                          }

                          return QualifiedObjectBuilder.BuildString(sb.ToString());
                      } catch (Exception e)
                      {
                          return QualifiedObjectBuilder.BuildString(e.ToString());
                      }
                  })
                  .RegisterParameter<string>("tsqlFilepath")
                  .Returns<string>()
                  .Build()
              ));


            environment.Define("SQL", QualifiedObjectBuilder.BuildNamespace(sqlNamespace));

            return 0;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            
            string filepath = @"C:\Users\joeba\Desktop\test.txt";

            var reader = new StringReader(File.ReadAllText(filepath));
            IList<ParseError> errors = null;
            var parser = new TSql150Parser(true, SqlEngineType.All);

            var tree = parser.Parse(reader, out errors);

            SqlTableCreatorVisitor visitor = new SqlTableCreatorVisitor();
            tree.Accept(visitor);

            foreach(var v in visitor.TableDefinitions)
            {
                Console.WriteLine(v);
            }

            Console.ReadKey();
        }
    }
}

