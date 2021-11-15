//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.CodeAnalysis;

    public interface ICodeSymbols<T> : IIndex<T>
        where T : ISymbol
    {
        CodeSymbol<T> Symbol(uint index);
    }

    public interface ICodeSymbols<H,T> : ICodeSymbols<T>
        where T : ISymbol
        where H : new()
    {
        new CodeSymbol<H,T> Symbol(uint index);

        CodeSymbol<T> ICodeSymbols<T>.Symbol(uint index)
            => Symbol(index);
    }
}