using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


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

                String TypingsJson = "{  \"ambientDependencies\": {    \"es6-shim\": \"registry:dt/es6-shim#0.31.2+20160317120654\",    \"jasmine\": \"registry:dt/jasmine#2.2.0+20160412134438\"  }}";

                String PackageJson = "{  \"name\": \"angular2-quickstart\",  \"version\": \"1.0.0\",  \"scripts\": {    \"start\": \"tsc && concurrently \\\"npm run tsc:w\\\" \\\"npm run lite\\\" \",    \"lite\": \"lite-server\",    \"postinstall\": \"typings install\",    \"tsc\": \"tsc\",    \"tsc:w\": \"tsc -w\",    \"typings\": \"typings\"  },  \"license\": \"ISC\",  \"dependencies\": {    \"@angular/common\":  \"2.0.0-rc.1\",    \"@angular/compiler\":  \"2.0.0-rc.1\",    \"@angular/core\":  \"2.0.0-rc.1\",    \"@angular/http\":  \"2.0.0-rc.1\",    \"@angular/platform-browser\":  \"2.0.0-rc.1\",    \"@angular/platform-browser-dynamic\":  \"2.0.0-rc.1\",    \"@angular/router\":  \"2.0.0-rc.1\",    \"@angular/router-deprecated\":  \"2.0.0-rc.1\",    \"@angular/upgrade\":  \"2.0.0-rc.1\",    \"systemjs\": \"0.19.27\",    \"es6-shim\": \"^0.35.0\",    \"reflect-metadata\": \"^0.1.3\",    \"rxjs\": \"5.0.0-beta.6\",    \"zone.js\": \"^0.6.12\",    \"angular2-in-memory-web-api\": \"0.0.7\",    \"bootstrap\": \"^3.3.6\"  },  \"devDependencies\": {    \"concurrently\": \"^2.0.0\",    \"lite-server\": \"^2.2.0\",    \"typescript\": \"^1.8.10\",    \"typings\":\"^0.8.1\"  }}";



                String  SystemJsConfig = @"
(function(global) {

  /// map tells the System loader where to look for things
  var map = {
    'app':                        'app', /// 'dist',
    'rxjs':                       'node_modules/rxjs',
    'angular2-in-memory-web-api': 'node_modules/angular2-in-memory-web-api',
    '@angular':                   'node_modules/@angular'
  };

  /// packages tells the System loader how to load when no filename and/or no extension
  var packages = {
    'app':                        { main: 'main.js',  defaultExtension: 'js' },
    'rxjs':                       { defaultExtension: 'js' },
    'angular2-in-memory-web-api': { defaultExtension: 'js' },
  };

  var packageNames = [
    '@angular/common',
    '@angular/compiler',
    '@angular/core',
    '@angular/http',
    '@angular/platform-browser',
    '@angular/platform-browser-dynamic',
    '@angular/router',
    '@angular/router-deprecated',
    '@angular/testing',
    '@angular/upgrade',
  ];

  /// add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
  packageNames.forEach(function(pkgName) {
    packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
  });

  var config = {
    map: map,
    packages: packages
  }

  /// filterSystemConfig - index.html's chance to modify config before we register it.
  if (global.filterSystemConfig) { global.filterSystemConfig(config); }

  System.config(config);

})(this);

";


                String g = WebUtility.HtmlDecode(@"
<html>
  <head>
    <title>Angular 2 QuickStart</title>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <link rel='stylesheet' href='styles.css'>

    <!-- 1. Load libraries -->
     <!-- Polyfill(s) for older browsers -->
    <script src='node_modules/es6-shim/es6-shim.min.js'></script>

    <script src='node_modules/zone.js/dist/zone.js'></script>
    <script src='node_modules/reflect-metadata/Reflect.js'></script>
    <script src='node_modules/systemjs/dist/system.src.js'></script>

    <!-- 2. Configure SystemJS -->
    <script src='systemjs.config.js'></script>
    <script>
      System.import('app').catch(function(err){ console.error(err);  });
    </script>
  </head>

  <!-- 3. Display the application -->
  <body>
    <my-app>Loading...</my-app>
  </body>
</html>
");




                String AppComponentTs  = @"
import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: '<h1>  Angular2  App   running successfully...</h1>'
})
export class AppComponent { }
";


                String mainTs = @"

import { bootstrap }    from '@angular/platform-browser-dynamic';

import { AppComponent } from './app.component';

bootstrap(AppComponent);
";




                // executing code


                String currentFolder = System.IO.Directory.GetCurrentDirectory();

                String t = "";

                //using (StreamWriter file = new System.IO.StreamWriter(@t, true))
                //{
                //    file.WriteLine("Fourth line");
                //}
                t = currentFolder + "tsconfig.json";


                using (StreamWriter file = new System.IO.StreamWriter(@"tsconfig.json", false))
                {
                    file.WriteLine(TSConfigJson);
                }


                using (StreamWriter file = new System.IO.StreamWriter(@"typings.json", false))
                {
                    file.WriteLine( TypingsJson);
                }




                using (StreamWriter file = new System.IO.StreamWriter(@"package.json", false))
                {
                    file.WriteLine(PackageJson);
                }




                using (StreamWriter file = new System.IO.StreamWriter(@"systemjs.config.js", false))
                {
                    file.WriteLine( SystemJsConfig);
                }



                using (StreamWriter file = new System.IO.StreamWriter(@"index.html", false))
                {
                    file.WriteLine( g );
                }





                
                


                System.Diagnostics.Process.Start("cmd.exe", "/c mkdir app");

                System.Diagnostics.Process.Start("cmd.exe", "cd /app");



                String fPath = currentFolder + "/app/app.component.ts";

                Console.Write(currentFolder);





                String s = currentFolder + "/app";


                if (System.IO.Directory.Exists(s))
                {

                    using (StreamWriter file = new System.IO.StreamWriter(fPath, false))
                    {
                        file.WriteLine(AppComponentTs);
                    }
                }
                else
                {

                    DirectoryInfo di = Directory.CreateDirectory(currentFolder + "/app");
                    using (StreamWriter file = new System.IO.StreamWriter(fPath, false))
                    {
                        file.WriteLine(AppComponentTs);
                    }


                }



                if (System.IO.Directory.Exists(s))
                {

                    String fPath1 = currentFolder + "/app/main.ts";

                    using (StreamWriter file = new System.IO.StreamWriter(fPath1, false))
                    {
                        file.WriteLine(mainTs);
                    }


                }
                else
                {

                    DirectoryInfo di = Directory.CreateDirectory(currentFolder + "/app");

                    String fPath1 = currentFolder + "/app/main.ts";

                    using (StreamWriter file = new System.IO.StreamWriter(fPath1, false))
                    {
                        file.WriteLine(mainTs);
                    }
                }






                 System.Diagnostics.Process.Start("cmd.exe", "/c npm install  & npm start ");

                 




                    





            }
            catch (Exception ex)
            {

                Console.Write(ex);



            }
        }
    }
}
