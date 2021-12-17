//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

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
            => ExprFormatters.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SeqRange((long min, long max) src)
            => new SeqRange(src.min, src.max);
    }
}