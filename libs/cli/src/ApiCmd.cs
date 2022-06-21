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

        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

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
            PdbIndexBuilder.IndexComponents(ApiMd.Components, dst);
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
            TableEmit(Cil.opcodes(), AppDb.DbOut("clr").Path("cil.opcodes", FileKind.Csv));
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
    }
}