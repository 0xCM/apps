//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public class AppModules : AppService<AppModules>
    {
        PdbIndexBuilder PdbIndexBuilder => Service(Wf.PdbIndexBuilder);

        public FS.FilePath IndexApiComponents()
            => IndexComponents(ApiRuntimeCatalog.Components);

        public FS.FilePath IndexComponents(Assembly[] src)
            => PdbIndexBuilder.IndexComponents(src);

        public FS.FilePath EmitPdbDocInfo(PartId part)
        {
            var components = ApiRuntimeCatalog.Components;
            var catalog = ApiRuntimeCatalog.PartCatalogs(part).Single();
            var partMethods = catalog.Methods.View;
            var assembly = catalog.Component;
            var module = assembly.ManifestModule;
            using var source = SymbolSource(FS.path(catalog.ComponentPath));
            var pePath = source.PePath;
            var pdbPath = source.PdbPath;
            var pdbReader = Wf.PdbReader(source);
            var counter = 0u;
            var dst = ProjectDb.Subdir("api/pdb") + FS.file(string.Format("{0}.pdbinfo", part.Format(), FS.Csv));
            using var writer = dst.Writer();
            var emitting = Wf.EmittingFile(dst);
            Write("Collecting methods");
            var pdbMethods = pdbReader.Methods;
            var methodCount = pdbMethods.Length;
            for(var i=0; i<methodCount; i++)
            {
                ref readonly var pdbMethod = ref skip(pdbMethods,i);
                var info = pdbMethod.Describe();
                var docview = info.Documents.View;
                var doc = docview.Length >=1 ? first(docview).Path : FS.FilePath.Empty;
                var token = info.Token;
                var methodBase = Clr.method(module,token);
                var name = methodBase.Name;
                var sig = methodBase is MethodInfo method ? method.DisplaySig().Format() : EmptyString;

                writer.WriteLine(string.Format("{0,-12} | {1,-24} | {2,-68} | {3}", token, name, doc.ToUri(), sig));
                counter++;
            }

            EmittedFile(emitting, counter);
            return dst;
        }

        public PdbSymbolSource SymbolSource(FileModule src)
        {
            try
            {
                return PdbSymbolSource.create(src.Path, src.Path.ChangeExtension(FS.Pdb));
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return PdbSymbolSource.Empty;
            }
        }

        public PdbSymbolSource SymbolSource(FS.FilePath module)
            => PdbSymbolSource.create(module);

        public ModuleArchive Archive()
            => ModuleArchive.create(FS.path(controller().Location).FolderPath);
    }
}