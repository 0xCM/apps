//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct Grammars
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static NamedTerm<T> term<T>(Name name, T value, params ITerm[] terms)
            => new NamedTerm<T>(name,value,terms);

        [MethodImpl(Inline)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);
    }
}

