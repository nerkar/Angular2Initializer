using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.IO;
namespace Angular2Initializer
{
    class Program
    {
        static void Main(string[] args)
        {



            try
            {

                String TSConfigJson = "{\"compilerOptions\": {    \"target\": \"es5\",    \"module\": \"commonjs\",    \"moduleResolution\": \"node\",    \"sourceMap\": true,    \"emitDecoratorMetadata\": true,    \"experimentalDecorators\": true,    \"removeComments\": false,    \"noImplicitAny\": false  },  \"exclude\": [    \"node_modules\",    \"typings/main\",   \"typings/main.d.ts\"]}";





                String currentFolder = System.IO.Directory.GetCurrentDirectory();

                String t = currentFolder + "\\writehere.txt";

                using (StreamWriter file = new System.IO.StreamWriter(@t, true))
                {
                    file.WriteLine("Fourth line");
                }
                t = currentFolder + "tsconfig.json";


                using (StreamWriter file = new System.IO.StreamWriter(@"tsconfig.json", true))
                {
                    file.WriteLine(TSConfigJson);
                }



                Console.Write(currentFolder);

            }
            catch (Exception ex)
            {

                Console.Write(ex);



            }
        }
    }
}
