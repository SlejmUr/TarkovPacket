using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace MakeClassFromACS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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

                if (resolvedItem.IsPublic)
                {
                    thingsToCSharp = "public";
                }
                else
                {
                    thingsToCSharp = "private";
                }
                if (resolvedItem.IsAbstract)
                {
                    thingsToCSharp += " abstract";
                }

                if (resolvedItem.IsSealed)
                {
                    thingsToCSharp += " sealed";
                }

                if (resolvedItem.IsClass)
                {
                    thingsToCSharp += " class";
                }
                else
                {
                    thingsToCSharp += " struct";
                }



                thingsToCSharp += $" {item.Name}";
                thingsToCSharp += $" : {item.BaseType.Name}";

                thingsToCSharp += "\n{\n";
                foreach (var fieldDefinition in resolvedItem.Fields)
                {
                    if (fieldDefinition.IsPublic)
                    {
                        thingsToCSharp += "\tpublic ";
                    }
                    else
                    {
                        thingsToCSharp += "\tprivate ";
                    }

                    Console.WriteLine(fieldDefinition.FieldType.ToString());
                    Console.WriteLine(fieldDefinition.FieldType.Name);
                    Console.WriteLine(fieldDefinition.FieldType.Namespace);
                    thingsToCSharp += fieldDefinition.FieldType.Name;
                    thingsToCSharp += " ";
                    thingsToCSharp += fieldDefinition.Name;
                    Console.WriteLine(fieldDefinition.FullName);
                    thingsToCSharp += ";\n";
                }
                thingsToCSharp += "}";
                File.WriteAllText($"test/test_{item.FullName}.cs", thingsToCSharp);
            }
        }
    }
}
