//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static ApiGranules;

    public partial class ApiCmd : AppCmdProvider<ApiCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        AsmTables AsmTables => Wf.AsmTables();

        ApiPacks ApiPacks => Wf.ApiPacks();

        AsmCallPipe AsmCalls => Wf.AsmCallPipe();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCatalogs ApiCatalogs => Wf.ApiCatalogs();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiCode ApiCode => Wf.ApiCode();

        AsmDocs AsmDocs => Wf.AsmDocs();

        Heaps Heaps => Wf.Heaps();

        PdbIndexBuilder PdbIndexBuilder => Service(Wf.PdbIndexBuilder);

        Index<ProcessAsmRecord> ProcessAsm()
            => Data(nameof(ProcessAsm), _LoadProcessAsm);

        Index<ProcessAsmRecord> ProcessAsmBuffer()
            => Data(nameof(ProcessAsmBuffer), () => alloc<ProcessAsmRecord>(ProcessAsm().Count));

        PdbSvc PdbSvc => Wf.PdbSvc();

        ApiResPackEmitter ResPackEmitter => Service(Wf.ResPackEmitter);

        Index<ProcessAsmRecord> _LoadProcessAsm()
            => ProcessAsmBuffers.records(ApiPacks.Current());


        [CmdOp("api/emit")]
        void ApiEmit()
        {
            ApiMd.EmitDatasets();
            AsmDocs.Emit();
        }

        [CmdOp("api/emit/pdb-info")]
        void EmitApiPdbInfo()
        {
            PdbSvc.EmitPdbDocInfo(PartId.AsmOperands);
        }

        [CmdOp("api/emit/cli")]
        void EmitMetadataCli()
        {
            CliEmitter.Emit(CliEmitOptions.@default());
            ApiMd.EmitMsil();
        }

        [CmdOp("api/pdb/index")]
        void IndexApiPdbFiles()
        {
            var dst = new PdbIndex();
            PdbIndexBuilder.IndexComponents(ApiRuntimeCatalog.Components, dst);
        }

        [CmdOp("api/emit/heaps")]
        void ApiEmitHeaps()
        {
            Heaps.Emit(Heaps.symbols(ApiMd.SymLits));
        }

        [CmdOp("api/emit/hexpacks")]
        Outcome EmitHexPack(CmdArgs args)
        {
            ApiCode.EmitHexPack(ApiCode.LoadBlocks());
            return true;
        }

        [CmdOp("api/emit/msil-host")]
        void EmitHostMsil(CmdArgs args)
            => ApiMd.EmitHostMsil(arg(args,0));

        [CmdOp("api/emit/msil")]
        void EmitMsil()
        {
            AppDb.MsilTargets().Delete();
            ApiMd.EmitMsil(ApiMd.ApiHosts, AppDb.MsilTargets(il));
            AppSvc.TableEmit(Cil.opcodes(), AppDb.Targets("clr").Path("cil.opcodes", FileKind.Csv));
        }

        [CmdOp("api/emit/index")]
        void EmitRuntimeMembers()
        {
            var service = ApiRuntime.create(Wf);
            var members = ApiMd.CalcRuntimeMembers();
            ApiMd.EmitIndex(members);
        }

        [CmdOp("api/parts")]
        void Parts()
        {
            iter(ApiMd.Parts, part => Write(part.Name));
        }

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
        {
            ApiMd.EmitComments();
        }

        [CmdOp("api/pdb/methods/symbols")]
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
        }

        [CmdOp("api/pdb/types/symbols")]
        void CollectTypeSymbols()
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

        }
    }
}