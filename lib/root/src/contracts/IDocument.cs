//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDocument : ITextual
    {
        ILocatable Source {get;}
    }

    public interface IDocument<D> : IDocument
        where D :  IDocument, new()
    {
        D Load(ILocatable src);
    }

    public interface IDocument<D,C> : IDocument<D>
        where D : IDocument, new()
        where C : struct, ITextual
    {
        C Content {get;}
    }

    public interface IDocument<D,C,L> : IDocument<D,C>
        where D :  IDocument, new()
        where C : struct, ITextual
        where L : struct, ILocatable
    {
        D Load(L location);

        new L Source {get;}

        ILocatable IDocument.Source
            => Source;

        D IDocument<D>.Load(ILocatable location)
            => Load((L)location);
    }
}