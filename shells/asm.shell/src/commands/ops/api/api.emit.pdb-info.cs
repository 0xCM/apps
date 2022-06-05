//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp("api/pdb/index")]
        void IndexApiPdbFiles()
        {
            PdbIndexBuilder.IndexComponents(ApiRuntimeCatalog.Components);
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

        PdbSvc PdbSvc => Wf.PdbSvc();

        [CmdOp("api/emit/pdb-info")]
        void EmitApiPdbInfo()
        {
            PdbSvc.EmitPdbDocInfo(PartId.Lib);
        }
    }
}