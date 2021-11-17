//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CaSymbolKey
    {
        public CaSymbol Symbol {get;}

        public ulong Key {get;}

        [MethodImpl(Inline)]
        public CaSymbolKey(CaSymbol symbol, ulong key)
        {
            Symbol = symbol;
            Key = key;
        }

        public string Format()
            => string.Format("{0:x} {1}", Key, Symbol.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CaSymbolKey((CaSymbol symbol, ulong key) src)
            => new CaSymbolKey(src.symbol, src.key);
    }
}