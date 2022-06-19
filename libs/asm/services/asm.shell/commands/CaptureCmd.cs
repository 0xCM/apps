//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static ApiGranules;

    public class CaptureCmd : AppCmdService<CaptureCmd>
    {
        AsmCallPipe AsmCalls => Wf.AsmCallPipe();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCode ApiCode => Wf.ApiCode();

        ApiPacks ApiPacks => Wf.ApiPacks();

        AsmTables AsmTables => Wf.AsmTables();

        Index<ProcessAsmRecord> ProcessAsm()
            => Data(nameof(ProcessAsm), _LoadProcessAsm);

        Index<ProcessAsmRecord> ProcessAsmBuffer()
            => Data(nameof(ProcessAsmBuffer), () => alloc<ProcessAsmRecord>(ProcessAsm().Count));

        ApiResPackEmitter ResPackEmitter => Service(Wf.ResPackEmitter);

        Index<ProcessAsmRecord> _LoadProcessAsm()
            => ProcessAsmBuffers.records(ApiPacks.Current());

        Index<HostAsmRecord> HostAsm()
        {
            Index<HostAsmRecord> Load()
            {
                var pack = ApiPacks.Current();
                var paths = pack.Archive().Tables();
                return AsmTables.LoadHostAsmRows(paths.Root);
            }
            return Data(nameof(HostAsm),Load);
        }

        [CmdOp("run/machine")]
        Outcome RunApiMachine(CmdArgs args)
        {
            using var machine = WfMachine.create(Wf);
            machine.Run(WorkflowOptions.@default());
            return true;
        }

        [CmdOp("api/emit/respack")]
        Outcome EmitResPack(CmdArgs args)
        {
            ResPackEmitter.Emit(ApiCode.LoadBlocks().Storage, false);
            return true;
        }

        [CmdOp("api/emit/asmblocks")]
        Outcome EmitApiAsmBlocks(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = ProjectDb.ApiTablePath<AsmDataBlock>();
            var hostasm = HostAsm();
            var blocks = AsmTables.DistillBlocks(hostasm);
            AsmTables.EmitBlocks(blocks, dst);
            return result;
        }

        [CmdOp("api/emit/asmcalls")]
        protected Outcome EmitCallTable(CmdArgs args)
        {
            var blocks = ApiCode.LoadBlocks();
            AsmCalls.EmitRows(AsmDecoder.Decode(blocks.Storage), ProjectDb.Subdir("api/asm/calls"));
            return true;
        }

        [CmdOp("api/capture")]
        void Capture(CmdArgs args)
            => Wf.ApiCapture().Run(args);

        [CmdOp("api/query/captured/asm/rex")]
        Outcome AsmQueryRex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.rex";
            var counter = 0u;
            var src = ProcessAsm().View;
            var buffer = ProcessAsmBuffer().Edit;
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.rex(src, ref i, buffer);
            var filtered = slice(buffer,0,count);
            var dst = ProjectDb.Subdir("api/queries") + FS.file("asm.rex", FS.Csv);
            AppSvc.TableEmit(@readonly(filtered), dst);
            return result;
        }
    }
}