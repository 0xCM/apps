//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    partial class AsmCases
    {
        public readonly struct MemOpCase<T>
            where T : unmanaged, IMemOp<T>
        {
            public readonly T Op;

            public readonly string OpFormat;

            [MethodImpl(Inline)]
            public MemOpCase(T op, string format)
            {
                Op = op;
                OpFormat = format;
            }

            [MethodImpl(Inline)]
            public static implicit operator MemOpCase(MemOpCase<T> src)
                => new MemOpCase(new MemOp(src.Op.Size, src.Op.Address), src.OpFormat);
        }
    }
}