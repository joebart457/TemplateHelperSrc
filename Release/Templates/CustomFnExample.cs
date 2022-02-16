using Mochj.Builders;
using Mochj.Models.Fn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportItems
{
    public class Export
    {
        public int Setup(Mochj._Storage.Environment environment)
        {
            Mochj._Storage.Environment customNamespace = new Mochj._Storage.Environment(null); // it is recommended to add the functions to a new environment below
                                                                                               // the one that is passed in to avoid name clashes


            customNamespace.Define("custom-function", // Function can be named whatever you like
              QualifiedObjectBuilder.BuildFunction(
                  new NativeFunction()
                  .Action((Args args) =>
                  {

                      // Custom Code here

                      // Retreive arguments of the specified type using
                      // the args.Get<Typename> method

                      string stringParam = args.Get<string>("stringParam");

                      // You can get arguments by name or by position
                      bool boolParam = args.Get<bool>(1);

                      double numberParam = args.Get<double>("doubleParam");

                      Console.WriteLine(stringParam);

                      // Make sure to build the result you'd like to return
                      // into a full QualifiedObject using QualifiedObjectBuilder.Build... method
                      return QualifiedObjectBuilder.BuildNumber(numberParam);


                      // End custom code
                  })
                  .RegisterParameter<string>("stringParam")
                  .RegisterParameter<bool>("boolParam")       // Can  define any number of parameters here
                  .RegisterParameter<double>("numberParam") 
                  .Returns<double>()                        // Can return int, double, string, bool, Environment, Function types here
                                                            // use .ReturnsEmpty() to return an empty value, but be sure to use
                                                            //  return QualifiedObjectBuilder.BuildEmptyValue(); in the action body
                  .Build()                                  // Make sure to call Build() at the end of the chain otherwise the 
                                                            // function will not register its parameters properly
              ));

            customNamespace.Define("custom-fn-2",
              QualifiedObjectBuilder.BuildFunction(
                  new NativeFunction()
                  .Action((Args args) =>
                  {
                      string result = "";
                      

                      return QualifiedObjectBuilder.BuildString(result);
                  })
                  .Returns<string>()
                  .Build()
              ));


            environment.Define("CustomNamespace", QualifiedObjectBuilder.BuildNamespace(customNamespace)); // Be sure to add the new namespace to the passed in environment object
                                                                                                           // otherwise nothing will be added to the environment

            // Now custom-fn will be available for use in scripting like:
            // %%% (CustomNamespace.custom-fn "teststring" true 345)

            return 0; // return OK
        }
    }
}

