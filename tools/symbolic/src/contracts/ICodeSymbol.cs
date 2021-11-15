//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.CodeAnalysis;

    public interface ICodeSymbol : INullity, ITextual
    {
        ISymbol Source {get;}

        SymbolKind Kind {get;}

        bool INullity.IsEmpty
            => Source == null;

        bool INullity.IsNonEmpty
            => Source != null;
        string ITextual.Format()
            => Source?.ToDisplayString() ?? "<null>";
    }

    public interface ICodeSymbol<T> : ICodeSymbol
        where T : ISymbol
    {
        new T Source {get;}

        ISymbol ICodeSymbol.Source
            => Source;
    }

    public interface ICodeSymbol<H,T> : ICodeSymbol<T>
        where H : new()
        where T : ISymbol
    {

    }
}