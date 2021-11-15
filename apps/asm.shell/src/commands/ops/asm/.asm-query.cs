//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".asm-query-rex")]
        Outcome AsmQueryRex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.rex";
            var counter = 0u;
            var records = State.ProcessAsm();
            var buffer = State.ProcessAsmSelection();
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.rex(records, ref i, buffer);
            var filtered = slice(buffer,0,count);
            PipeQueryOut(@readonly(filtered), Z0.ProcessAsmRecord.RenderWidths, qid);
            return result;
        }

        [CmdOp(".asm-query-vex")]
        Outcome AsmQueryVex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.vex";

            var counter = 0u;
            var records = State.ProcessAsm();
            var buffer = State.ProcessAsmSelection();
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.vex(records, ref i, buffer);
            var filtered = slice(buffer,0,count);
            PipeQueryOut(@readonly(filtered), Z0.ProcessAsmRecord.RenderWidths, qid);
            return result;
        }
    }
}