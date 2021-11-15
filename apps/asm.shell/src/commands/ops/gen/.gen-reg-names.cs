//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".gen-reg-names")]
        Outcome EmitRegNames(CmdArgs args)
        {
            var dst = Ws.Gen().Path("cs","regnames", FS.Cs);
            var flow = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var regs = AsmRegData.gp();
            var count = regs.Length;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                if(i != 0 && i%4 == 0)
                    buffer.AppendLine();

                ref readonly var reg = ref skip(regs,i);
                buffer.AppendFormat("{0,-6}", reg);
            }
            var bytespan = SpanRes.specify("GpRegNames", recover<RegOp,byte>(regs).ToArray());
            writer.WriteLine(bytespan.Format());
            EmittedFile(flow, regs.Length);

            return true;
        }
    }
}