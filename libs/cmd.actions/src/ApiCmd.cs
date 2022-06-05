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

        Index<ProcessAsmRecord> ProcessAsm()
            => Data(nameof(ProcessAsm), _LoadProcessAsm);

        Index<ProcessAsmRecord> ProcessAsmBuffer()
            => Data(nameof(ProcessAsmBuffer), () => alloc<ProcessAsmRecord>(ProcessAsm().Count));

        ApiResPackEmitter ResPackEmitter => Service(Wf.ResPackEmitter);

        Index<ProcessAsmRecord> _LoadProcessAsm()
        {
            var archive = ApiPacks.Current().Archive();
            var path = archive.ProcessAsmPath();
            var count = FS.linecount(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var flow = Running(string.Format("Loading process asm from {0}", path.ToUri()));
            var result = AsmTables.load(path, buffer);
            if(result.Fail)
            {
                Error(result.Message);
                return Index<ProcessAsmRecord>.Empty;
            }
            Ran(flow);

            return buffer;
        }

        [CmdOp("api/emit")]
        void ApiEmit()
        {
            ApiMd.EmitDatasets();
            AsmDocs.Emit();
        }

        [CmdOp("api/emit/cli")]
        void EmitMetadataCli()
        {
            CliEmitter.Emit(CliEmitOptions.@default());
            ApiMd.EmitMsil();
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

    }
}