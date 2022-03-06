//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EnumFormatter<E> : IFormatter<E>
        where E : unmanaged, Enum
    {
        readonly Symbols<E> Syms;

        public EnumFormatter()
        {
            Syms = Symbols.index<E>();
        }

        [MethodImpl(Inline)]
        public string Format(E src)
            => Syms[src].Expr.Text;
    }
}