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
    /// Lifts an enumeration literal to a type
    /// </summary>
    public readonly struct RefinedLiteral<T> : ILiteralValue<T>
        where T : unmanaged, Enum, IEquatable<T>
    {
        /// <summary>
        /// The classifying literal
        /// </summary>
        public T Data {get;}

        public ClrLiteralKind Kind {get;}

        public Name Name => Data.ToString();

        [MethodImpl(Inline)]
        public RefinedLiteral(T @class, ClrEnumKind kind)
        {
            Data = @class;
            Kind = (ClrLiteralKind)kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator T(RefinedLiteral<T> t)
            => t.Data;

        [MethodImpl(Inline)]
        public static implicit operator RefinedLiteral<T>(T value)
            => api.refined(value);
    }
}