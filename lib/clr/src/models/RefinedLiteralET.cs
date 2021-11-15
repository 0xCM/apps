//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = ClrLiterals;

    /// <summary>
    /// A numeric-parametric typed literal
    /// </summary>
    /// <typeparam name="E">An enumeration type that refines the parametric numeric type</typeparam>
    /// <typeparam name="T">The numeric type refined by the enum</typeparam>
    public struct RefinedLiteral<E,T>
        where E : unmanaged, Enum, IEquatable<E>
        where T : unmanaged, IEquatable<T>
    {
        public E Value {get;}

        public T Scalar {get;}

        [MethodImpl(Inline)]
        public RefinedLiteral(E value, T scalar)
        {
            Value = value;
            Scalar = scalar;
        }

        public ClrEnumKind ScalarKind
        {
            [MethodImpl(Inline)]
            get => Enums.kind<E>();
        }


        public bool Equals(RefinedLiteral<E,T> src)
            => src.Value.Equals(Value);

        public override bool Equals(object src)
            => src is RefinedLiteral<E,T> r && Equals(r);

        public override int GetHashCode()
            => Value.GetHashCode();

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(RefinedLiteral<E,T> x, RefinedLiteral<E,T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(RefinedLiteral<E,T> x, RefinedLiteral<E,T> y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static implicit operator E(RefinedLiteral<E,T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(RefinedLiteral<E,T> src)
            => src.Scalar;

        [MethodImpl(Inline)]
        public static implicit operator RefinedLiteral<E,T>(E @class)
            => api.define<E,T>(@class);

        [MethodImpl(Inline)]
        public static implicit operator RefinedLiteral<E,T>(T value)
            => api.refined<E,T>(value);
    }
}