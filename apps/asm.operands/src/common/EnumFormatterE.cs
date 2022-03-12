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
        {
            if(Syms.MapKind(src, out var a))
                return a.Expr.Text;
            else if(Syms.MapValue(core.bw64(src), out var b))
                return b.Expr.Text;
            else
                return RP.Error;
        }
    }
}