//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class CaptureCmd : AppCmdService<CaptureCmd>
    {
        AsmCallPipe AsmCalls => Wf.AsmCallPipe();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCode ApiCode => Wf.ApiCode();

        ApiPacks ApiPacks => Wf.ApiPacks();

        AsmTables AsmTables => Wf.AsmTables();

        ImageRegions Regions => Wf.ImageRegions();

        Runtime Runtime => Wf.Runtime();

        IApiPack Dst => ApiPack.create();

        ReadOnlySeq<HostAsmRecord> HostAsm()
        {
            var pack = ApiPacks.Current();
            var paths = pack.Archive().Tables();
            return AsmTables.LoadHostAsmRows(paths.Root);
        }

        void EmitApiAsmBlocks()
        {
            var result = Outcome.Success;
            var dst = ProjectDb.ApiTablePath<AsmDataBlock>();
            var hostasm = HostAsm();
            var blocks = AsmTables.DistillBlocks(hostasm);
            AsmTables.EmitBlocks(blocks, dst);
        }

        void EmitCallTable()
        {
            var blocks = ApiCode.LoadBlocks();
            AsmCalls.EmitRows(AsmDecoder.Decode(blocks.Storage), ProjectDb.Subdir("api/asm/calls"));
        }

        [CmdOp("cli/options")]
        void CliOptions()
        {
            var src = CliEmitOptions.@default();
            //var settings = Settings.settings(src);
            var path = AppDb.ConfigPath<CliEmitOptions>();
            var settings = Settings.config(path);
            Row(settings.Format());
            // Row(settings.Format());

            // Row(settings.Format());
            // FileEmit(settings.Format(),path);
        }

        [CmdOp("capture")]
        void Capture(CmdArgs args)
            => Wf.ApiCapture().Run(Dst);

        [CmdOp("capture/regions")]
        void CaptureRegions()
        {
            var process = Process.GetCurrentProcess();
            var regions = Regions.EmitRegions(process, Dst);
            //ProcessMemory.EmitHashes(process, regions, dst);
        }

        [CmdOp("capture/context")]
        void CaptureContext()
            => Runtime.EmitContext(Dst);

        Outcome AsmQueryRex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.rex";
            var counter = 0u;
            var src = ProcessAsmBuffers.records(ApiPacks.Current());
            var buffer = span<ProcessAsmRecord>(src.Count);
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.rex(src, ref i, buffer);
            var filtered = slice(buffer,0,count);
            var dst = AppDb.App().Path(FS.file("asm.rex", FS.Csv));
            TableEmit(@readonly(filtered), dst);
            return result;
        }
    }
}