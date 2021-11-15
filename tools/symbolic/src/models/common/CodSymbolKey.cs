//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CodeSymbolKey
    {
        public CodeSymbol Symbol {get;}

        public ulong Key {get;}

        [MethodImpl(Inline)]
        public CodeSymbolKey(CodeSymbol symbol, ulong key)
        {
            Symbol = symbol;
            Key = key;
        }

        public string Format()
            => string.Format("{0:x} {1}", Key, Symbol.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbolKey((CodeSymbol symbol, ulong key) src)
            => new CodeSymbolKey(src.symbol, src.key);
    }
}