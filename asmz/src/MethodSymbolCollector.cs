//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static core;
    using static CodeSymbolModels;

    public class MethodSymbolCollector
    {
        List<MethodSymbol> Symbols;

        public MethodSymbolCollector()
        {
            Symbols = new();
        }

        public void Deposit(ReadOnlySpan<MethodSymbol> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Symbols.Add(skip(src,i));
        }

        public ReadOnlySpan<MethodSymbol> Collected
            => Symbols.ViewDeposited();
    }
}