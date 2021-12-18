//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;
    using System.Reflection;

    using static core;
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp("api/pdb/index")]
        Outcome IndexApiPdbFiles(CmdArgs args)
        {
            var components = ApiRuntimeCatalog.Components;
            PdbIndexBuilder.IndexComponents(ApiRuntimeCatalog.Components);
            return true;
        }

        [CmdOp("api/pdb/methods/symbols")]
        Outcome CollectComponentSymbols(CmdArgs args)
        {
            var components = ApiRuntimeCatalog.Components;
            var flow = Running(string.Format("Collecting method symbols for {0} assemblies", components.Length));
            var symbolic = Wf.SourceSymbolic();
            var collector = new MethodSymbolCollector();
            symbolic.SymbolizeMethods(components, collector.Deposit);
            var items = collector.Collected;
            var count = items.Length;
            Ran(flow, string.Format("Collected {0} method symbols", count));
            var dst = Ws.Project("db").Path("api","methods", FS.Md);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref skip(items,i);
                var doc = item.Docs;
                var summary = doc != null ? doc.SummaryText.Trim() : EmptyString;
                if(nonempty(summary))
                    writer.WriteLine(string.Format("// {0}",summary));
                writer.WriteLine(item.Format());
            }
            EmittedFile(emitting, count);
            return true;
        }

        [CmdOp("api/pdb/types/symbols")]
        Outcome CollectTypeSymbols(CmdArgs args)
        {
            var components = ApiRuntimeCatalog.Components;
            var symbolic = Wf.SourceSymbolic();
            var dst = Ws.Project("db").Path("api", "types", FS.Md);
            var emitting = EmittingFile(dst);
            var counter =0u;
            using var writer = dst.Writer();
            foreach(var component in components)
            {
                var symbols = symbolic.Symbolize(component);
                var items = symbols.Types;
                var count = items.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var item =ref skip(items,i);
                    var doc = item.Docs;
                    var summary = doc != null ? doc.SummaryText.Trim() : EmptyString;
                    if(nonempty(summary))
                        writer.WriteLine(string.Format("// {0}",summary));
                    writer.WriteLine(item.Format());
                }
            }

            return true;
        }

        [CmdOp("api/emit/pdb-info")]
        Outcome EmitApiPdbInfo(CmdArgs arg)
        {
            EmitPdbDocInfo(PartId.Lib);
            return true;
        }

        void EmitPdbDocInfo(PartId part)
        {
            var components = ApiRuntimeCatalog.Components;
            var catalog = ApiRuntimeCatalog.PartCatalogs(part).Single();
            var partMethods = catalog.Methods.View;
            var assembly = catalog.Component;
            var module = assembly.ManifestModule;
            using var source = AppModules.SymbolSource(FS.path(catalog.ComponentPath));
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
        }
    }
}