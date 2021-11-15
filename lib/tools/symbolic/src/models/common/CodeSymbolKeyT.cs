//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CodeSymbolKey<T>
        where T : ICodeSymbol
    {
        public T Symbol {get;}

        public ulong Key {get;}

        [MethodImpl(Inline)]
        public CodeSymbolKey(T symbol, ulong key)
        {
            Symbol = symbol;
            Key = key;
        }

        public string Format()
            => string.Format("{0:x} {1}", Key, Symbol.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbolKey(CodeSymbolKey<T> src)
            => new CodeSymbolKey(new CodeSymbol(src.Symbol.Source), src.Key);

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbolKey<T>((T symbol, ulong key) src)
            => new CodeSymbolKey<T>(src.symbol, src.key);
    }
}