using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_processor.Services;

namespace template_processor
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProcessingService().Process(@"C:\zzz_WIP\Templates\Template", @"C:\zzz_WIP\Templates\Sandbox");

            Console.ReadKey();

        }
    }
}
