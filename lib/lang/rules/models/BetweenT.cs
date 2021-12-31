//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Between<T>
    {
        public readonly T Min;

        public readonly T Max;

        public Between(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public Label Name => "between<{0}>";

        public string Format()
            => rules.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Between<T>((T min, T max) src)
            => new Between<T>(src.min, src.max);
    }
}