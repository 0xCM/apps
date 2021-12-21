//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EnumParser<E> : IParser<E>
        where E : unmanaged, Enum
    {
        readonly Symbols<E> Syms;

        public EnumParser()
        {
            Syms = Symbols.index<E>();
        }

        public Outcome Parse(string src, out E dst)
        {
            if(Syms.Lookup(src, out var sym))
            {
                dst = sym.Kind;
                return true;
            }
            else
            {
                dst = default;
                return (false, string.Format("The value '{0}' could not be interpreted as a {1} member", src, typeof(E).Name));
            }
        }
    }
}