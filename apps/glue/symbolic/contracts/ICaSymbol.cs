//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.CodeAnalysis;

    public interface ICaSymbol : INullity, ITextual
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

    public interface ICaSymbol<T> : ICaSymbol
        where T : ISymbol
    {
        new T Source {get;}

        ISymbol ICaSymbol.Source
            => Source;
    }

    public interface ICaSymbol<H,T> : ICaSymbol<T>
        where H : new()
        where T : ISymbol
    {

    }
}