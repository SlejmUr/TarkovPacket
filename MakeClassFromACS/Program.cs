using Mono.Cecil;
using Mono.Cecil.Rocks;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.ProjectDecompiler;
using ICSharpCode.Decompiler.DebugInfo;
using ICSharpCode.Decompiler.Disassembler;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.Solution;
using ICSharpCode.Decompiler.TypeSystem;

namespace MakeClassFromACS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string assemblyFileName = "Assembly-CSharp.dll";

            var module = new PEFile(assemblyFileName);
            var resolver = new UniversalAssemblyResolver(assemblyFileName, false, module.Metadata.DetectTargetFrameworkId());

            CSharpDecompiler decompiler =  new CSharpDecompiler(assemblyFileName, resolver, new DecompilerSettings( LanguageVersion.Latest ));

            //decompiler.DecompileTypeAsString();
            
            List<TypeDefinition> Descriptors = new();
            var def = AssemblyDefinition.ReadAssembly("Assembly-CSharp.dll");

            foreach (var typeDefinition in def.MainModule.Types)
            {
                if (typeDefinition.HasCustomAttributes)
                {
                    var defs = typeDefinition.CustomAttributes.Where(a => !a.AttributeType.FullName.Contains("Unity")  && !a.AttributeType.FullName.Contains("System") && !a.AttributeType.FullName.Contains("JetBrains")).ToList();
                    
                    if (defs.Any())                    
                    {
                        Console.WriteLine();
                        Console.WriteLine(typeDefinition.FullName);
                        foreach (var item in defs)
                        {
                            Console.WriteLine(item.AttributeType.FullName);
                            if (item.AttributeType.FullName == "DescriptorAttribute")
                                Descriptors.Add(typeDefinition);
                        }
                    }
                }
            }

            Console.WriteLine();
            //
            foreach (var item in Descriptors)
            {
                string thingsToCSharp = "";


                var resolvedItem = item.Resolve();
                
                var name = new FullTypeName(resolvedItem.FullName);
                thingsToCSharp = decompiler.DecompileTypeAsString(name);
                File.WriteAllText($"test/test_{item.FullName}.cs", thingsToCSharp);
            }
        }
    }
}
