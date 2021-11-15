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

    /// <summary>
    /// Constrains an element or sequence to live within a specified range
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SeqRange<T> : IExpr
    {
        /// <summary>
        /// The min value in the range
        /// </summary>
        public readonly Value<T> Min;

        /// <summary>
        /// The max value in the range
        /// </summary>
        public readonly Value<T> Max;

        [MethodImpl(Inline)]
        public SeqRange(Value<T> min, Value<T> max)
        {
            Min = min;
            Max = max;
        }

        public string Format()
            => expr.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SeqRange<T>((T min, T max) src)
            => new SeqRange<T>(src.min, src.max);
    }
}