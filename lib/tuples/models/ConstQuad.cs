//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// An homogenous immutable 4-tuple
    /// </summary>
    public readonly struct ConstQuad<T> : ITupled<ConstQuad<T>,T,T,T,T>, ITextual
    {
        /// <summary>
        /// The first member
        /// </summary>
        public readonly T First;

        /// <summary>
        /// The second member
        /// </summary>
        public readonly T Second;

        /// <summary>
        /// The third member
        /// </summary>
        public readonly T Third;

        /// <summary>
        /// The fourth member
        /// </summary>
        public readonly T Fourth;

        [MethodImpl(Inline)]
        public ConstQuad(T a, T b, T c, T d)
        {
            First = a; Second = b; Third = c; Fourth = d;
        }

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => i == 0 ? First : i == 1 ? Second : i == 2 ? Third : Fourth;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T a, out T b, out T c, out T d)
        {
            a = First; b = Second; c = Third; d = Fourth;
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public ConstQuad<U> As<U>()
            where U : unmanaged
                => Unsafe.As<ConstQuad<T>,ConstQuad<U>>(ref Unsafe.AsRef(in this));

        [MethodImpl(Inline)]
        public bool Equals(ConstQuad<T> rhs)
            => First.Equals(rhs.First) && Second.Equals(rhs.Second) && Third.Equals(rhs.Third) && Fourth.Equals(rhs.Fourth);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({First},{Second},{Third},{Fourth})" : $"{First}x{Second}x{Third}x{Fourth}";

        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => HashCode.Combine(First,Second,Third);

        public override bool Equals(object obj)
            => obj is ConstQuad<T> x && Equals(x);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public Y Map<Y>(Func<ConstQuad<T>,Y> f)
            => f(this);

        [MethodImpl(Inline)]
        public static implicit operator ConstQuad<T>(in (T a, T b, T c, T d) src)
            => new ConstQuad<T>(src.a,src.b,src.c,src.d);

        [MethodImpl(Inline)]
        public static implicit operator ConstQuad<T>(in (ConstPair<T> a, ConstPair<T> b) src)
            => new ConstQuad<T>(src.a.Left,src.a.Right, src.b.Left,src.b.Right);

        [MethodImpl(Inline)]
        public static bool operator ==(in ConstQuad<T> a, in ConstQuad<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(in ConstQuad<T> a, in ConstQuad<T> b)
            => a.Equals(b);
    }
}