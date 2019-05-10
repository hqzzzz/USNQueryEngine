# USNQueryEngine
## Replacement Everything.  I don't want to use IPC. 

* [**GitHub repository**](https://github.com/hqzzzz/USNQueryEngine)


If you don't know what is Everything , just look at [**here**](https://en.wikipedia.org/wiki/Everything_(software))

# How does it work?

* Read USN
* Find USN logs

![Image text](https://raw.githubusercontent.com/hqzzzz/USNQueryEngine/master/bin/EngineTestConsole.png)

# Make it in One Dll.

```
(ProjectDir)ILMerge\ILMerge.exe /ndebug  /targetPlatform:v4  /target:dll /out:$(SolutionDir)bin\$(TargetFileName) $(TargetDir)PInvoke.dll  $(TargetDir)UsnOperation.dll $(TargetDir)USNQueryEngine.dll
```

# How to use?

* C#

1. Introducing Dll files

2. Reference `<Enginetest>`  

```C#
using USNQueryEngine;

class Program
{
 static void Main(string[] args)
 {
   

     var entries = USNEngine.GetAllFilesAndDirectories();
     var result = entries
             .Where(f => f.FileName.ToUpper().Contains(filter))
             .OrderBy(f => f.FileName)
             .ToList();

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
 }
}
```
# Related Projects
* [**Artwalk/Fake-Everything**](https://github.com/Artwalk/Fake-Everything) — C++ Edition
