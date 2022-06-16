//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ApiGranules;

    public class ApiCmd : AppCmdService<ApiCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        CliEmitter CliEmitter => Wf.CliEmitter();

        Heaps Heaps => Wf.Heaps();

        PdbIndexBuilder PdbIndexBuilder => Service(Wf.PdbIndexBuilder);

        PdbSvc PdbSvc => Wf.PdbSvc();

        [CmdOp("api/etl")]
        void ApiEmit()
        {
            ApiMd.EmitDatasets();
        }

        [CmdOp("api/emit/pdb/info")]
        void EmitApiPdbInfo()
            => PdbSvc.EmitPdbDocInfo(PartId.AsmOperands);

        [CmdOp("api/emit/cli")]
        void EmitMetadataCli()
        {
            CliEmitter.Emit(CliEmitOptions.@default());
            ApiMd.EmitMsil();
        }

        [CmdOp("api/emit/pdb/index")]
        void IndexApiPdbFiles()
        {
            var dst = new PdbIndex();
            PdbIndexBuilder.IndexComponents(ApiRuntimeCatalog.Components, dst);
        }

        [CmdOp("api/emit/heaps")]
        void ApiEmitHeaps()
            => Heaps.Emit(Heaps.symbols(ApiMd.SymLits));

        [CmdOp("api/emit/msil-host")]
        void EmitHostMsil(CmdArgs args)
            => ApiMd.EmitHostMsil(arg(args,0));

        [CmdOp("api/emit/msil")]
        void EmitMsil()
        {
            var targets = AppDb.ApiTargets(msil);
            targets.Delete();
            ApiMd.EmitMsil(ApiMd.ApiHosts, targets.Targets(il));
            AppSvc.TableEmit(Cil.opcodes(), AppDb.DbTargets("clr").Path("cil.opcodes", FileKind.Csv));
        }

        [CmdOp("api/emit/index")]
        void EmitRuntimeMembers()
            => ApiMd.EmitIndex(ApiMd.CalcRuntimeMembers());

        [CmdOp("api/parts")]
        void Parts()
            => iter(ApiMd.Parts, part => Write(part.Name));

        [CmdOp("api/components")]
        void Components()
            => iter(ApiMd.Components, part => Write(part.GetSimpleName()));

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
            => ApiMd.EmitComments();

        [CmdOp("api/emit/pdb/methsyms")]
        void CollectComponentSymbols()
        {
            var components = ApiRuntimeCatalog.Components;
            var flow = Running(string.Format("Collecting method symbols for {0} assemblies", components.Length));
            var symbolic = Wf.SourceSymbolic();
            var collector = new MethodSymbolCollector();
            symbolic.SymbolizeMethods(components, collector.Deposit);
            var items = collector.Collected;
            var count = items.Length;
            Ran(flow, string.Format("Collected {0} method symbols", count));
            var dst = AppDb.ApiTargets().Path("api","methods", FileKind.Md);
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
        }

        [CmdOp("api/emit/pdb/typesyms")]
        void CollectTypeSymbols()
        {
            var components = ApiRuntimeCatalog.Components;
            var symbolic = Wf.SourceSymbolic();
            var dst = AppDb.ApiTargets().Path("api", "types", FileKind.Md);
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
        }
    }
}