//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EnumRender<E> : IFormatter<E>
        where E : unmanaged, Enum
    {
        public static EnumRender<E> Service => new();

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


        [MethodImpl(Inline)]
        public string Format(E src, bool id)
        {
            if(id)
            {
                if(Syms.MapKind(src, out var a))
                    return a.Identity;
                else if(Syms.MapValue(core.bw64(src), out var b))
                    return b.Identity;
                else
                    return RP.Error;
            }
            else
                return Format(src);
        }

        static readonly Symbols<E> Syms;

        static EnumRender()
        {
            Syms = Symbols.index<E>();
        }
    }
}