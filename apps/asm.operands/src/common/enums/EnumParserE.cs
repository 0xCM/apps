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
            Outcome result = (false, AppMsg.ParseFailure.Format(typeof(E).Name, src));
            dst = default;
            if(Syms.Lookup(src, out var sym))
            {
                dst = sym.Kind;
                result = true;
            }
            else
            {
                if(Enums.parse(src, out dst))
                    result = true;
            }
            return result;
        }
    }
}