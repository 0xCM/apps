//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using XF = ExprPatterns;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SeqRange : IExpr
    {
        public long Min {get;}

        public long Max {get;}

        [MethodImpl(Inline)]
        public SeqRange(long min, long max)
        {
            Min = min;
            Max = max;
        }

        public string Format()
            => string.Format(XF.InclusiveRange, Min, Max);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SeqRange((long min, long max) src)
            => new SeqRange(src.min, src.max);
    }
}