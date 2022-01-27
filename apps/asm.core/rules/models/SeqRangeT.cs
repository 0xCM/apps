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

    using XF = ExprPatterns;

    /// <summary>
    /// Constrains an element or sequence to live within a specified range
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SeqRange<T> : IExpr
        where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// The min value in the range
        /// </summary>
        public T Min {get;}

        /// <summary>
        /// The max value in the range
        /// </summary>
        public T Max {get;}

        [MethodImpl(Inline)]
        public SeqRange(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public string Format()
            => string.Format(XF.InclusiveRange, Min, Max);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SeqRange<T>((T min, T max) src)
            => new SeqRange<T>(src.min, src.max);
    }
}