//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RuntimeLiteralValue<T> : ITextual
        where T : IEquatable<T>
    {
        public T Data {get;}

        [MethodImpl(Inline)]
        public RuntimeLiteralValue(T src)
        {
            Data = src;
        }

        public string Format()
            => ApiLiterals.format(this);

        public override string ToString()
            => Format();
    }
}