//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    partial class AsmCmdService
    {
        uint PipeQueryOut<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, string id)
            where T : struct
        {
            var dst = OutWs.QueryOut(id, FS.Csv);
            var count = TableEmit(src, widths, dst);
            Write(string.Format("Emitted {0}", dst.Format(PathSeparator.BS)));
            return count;
        }
    }
}