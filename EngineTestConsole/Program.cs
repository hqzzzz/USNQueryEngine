using Colorful;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using USNQueryEngine;
using Console = Colorful.Console;


namespace EngineTestConsole
{
    class Program
    {
        private  static List<FileAndDirectoryEntry> entries;
        static void Main(string[] args)
        {
           
            Console.WriteAscii("USNQueryEngine", Color.FromArgb(240,200, 200));
            Stopwatch watch = new Stopwatch();

            watch.Start();

            entries = USNEngine.GetAllFilesAndDirectories();

            watch.Stop();

            Console.WriteLine("{0} files, {1} seconds", entries.Count(), watch.Elapsed.TotalSeconds);
            string filter = "UsnOperation.dll".ToUpper();
            Formatter[] fruits = new Formatter[]
                {  
                    new Formatter($"{filter}", Color.LawnGreen),
                };
            Console.WriteLineFormatted("Start to Serch [{0}]", Color.Gray, fruits);
            Console.WriteLine();

            watch.Restart();
            var result = entries
                    .Where(f => f.FileName.ToUpper().Contains(filter))
                    .OrderBy(f => f.FileName)
                    .ToList();

            watch.Stop();

            Console.WriteLine("{0} files in {1} seconds", result.Count(), watch.Elapsed.TotalSeconds);
            if (result.Count()>0)
            {

                var table = new ConsoleTable("FileName", "Path");
                foreach (var item in result)
                {
                    if (item is FileAndDirectoryEntry)
                    {
                        table.AddRow(item.FileName, item.Path);
                    }
                }
                table.Write();
                Console.WriteLine();
            }
          
         
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
