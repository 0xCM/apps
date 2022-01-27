//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct BetweenRule<T>
    {
        public readonly T Min;

        public readonly T Max;

        public BetweenRule(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public Label Name => "between<{0}>";

        public string Format()
            => Rules.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BetweenRule<T>((T min, T max) src)
            => new BetweenRule<T>(src.min, src.max);
    }
}