//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    using Asm;

    partial class CheckCmdProvider
    {
        ProcessAsmBuffers ProcessAsmBuffers => Service(Wf.ProcessAsmBuffers);

        [CmdOp("check/process/asm")]
        Outcome CheckProcessAsm(CmdArgs args)
        {
            var buffers = ProcessAsmBuffers;
            var vex = buffers.Vex();
            var count = vex.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(vex,i);
                Write(string.Format("{0,-64} | {1,-28} | {2}", record.Statement, record.OpCode, record.Encoded));
            }

            return true;
        }

    }
}