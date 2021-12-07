//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;

    using static core;
    using static Root;

    partial class AsmCmdService
    {
        IApiCatalog ApiRuntimeCatalog => Service(ApiRuntimeLoader.catalog);

        [CmdOp(".api-pdbs")]
        Outcome IndexApiPdbFiles(CmdArgs args)
        {
            var components = ApiRuntimeCatalog.Components;
            var builder = Wf.PdbIndexBuilder();
            builder.IndexComponents(components);
            return true;
        }

        [CmdOp(".collect-symbols")]
        Outcome CollectComponentSymbols(CmdArgs args)
        {
            var catalog = State.ApiCatalog(ApiRuntimeLoader.catalog);
            var components = catalog.Components;
            var flow = Wf.Running(string.Format("Collecting method symbols for {0} assemblies", components.Length));
            var symbolic = Wf.SourceSymbolic();
            var collector = new MethodSymbolCollector();
            symbolic.SymbolizeMethods(components, collector.Deposit);
            var items = collector.Collected;
            var count = items.Length;
            Wf.Ran(flow, string.Format("Collected {0} method symbols", count));
            var dst = Ws.Project("db").Path("api","methods", FS.Md);
            var emitting = Wf.EmittingFile(dst);
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
            Wf.EmittedFile(emitting, count);
            return true;
        }

        [CmdOp(".collect-type-symbols")]
        Outcome CollectTypeSymbols(CmdArgs args)
        {
            var catalog = State.ApiCatalog(ApiRuntimeLoader.catalog);
            var components = catalog.Components;
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


        [CmdOp(".api-members")]
        Outcome ApiMembers(CmdArgs args)
        {
            var result = Outcome.Success;
            var entries = ApiCatalogs.LoadApiCatalog(ApiPackArchive.ApiCatalog());
            iter(entries, e => Write(e.OpUri));
            return result;
        }

        [CmdOp(".emit-symbol-span")]
        Outcome EmitSymIndex(CmdArgs srgs)
        {
            var result = Outcome.Success;
            var dst = Ws.Project("gen").Subdir("symbols") + FS.file("symindex", FS.Cs);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            EmitSymbolSpan<AsciLetterLoSym>("AsciLetterLoSym", writer);
            EmittedFile(emitting, 1);
            return result;
        }

        Outcome EmitSymbolSpan<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var result = Outcome.Success;
            var buffer = text.buffer();
            SpanRes.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
            return result;
        }
    }
}