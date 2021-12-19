//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EnumParser<K> : IParser<K>
        where K : unmanaged, Enum
    {
        readonly Symbols<K> Syms;

        public EnumParser()
        {
            Syms = Symbols.index<K>();
        }

        public Outcome Parse(string src, out K dst)
        {
            if(Syms.Lookup(src, out var sym))
            {
                dst = sym.Kind;
                return true;
            }
            else
            {
                dst = default;
                return (false, string.Format("The value '{0}' could not be interpreted as a {1} member", src, typeof(K).Name));
            }
        }
    }
}