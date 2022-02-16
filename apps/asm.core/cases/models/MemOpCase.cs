//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCases
    {
        public readonly struct MemOpCase
        {
            public readonly MemOp Op;

            public readonly string OpFormat;

            [MethodImpl(Inline)]
            public MemOpCase(MemOp op, string format)
            {
                Op = op;
                OpFormat = format;
            }
        }
    }
}