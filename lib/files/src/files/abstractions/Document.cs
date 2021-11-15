//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Document<D> : Universe<D>, IDocument<D>
        where D : Document<D>, new()
    {
        public ILocatable Source {get;}

        protected Document(ILocatable src)
        {
            Source = src;
        }

        protected Document()
        {
            Source = Locatable.Empty;
        }

        public abstract D Load(ILocatable location);

        public abstract string Format();
    }

    public abstract class Document<D,C> : Document<D>, IDocument<D,C>
        where D : Document<D,C>, new()
        where C : struct, ITextual
    {
        [MethodImpl(Inline)]
        public static D load(C content)
            => new D().WithContent(content);

        public C Content {get; private set;}

        protected Document(C content)
            : base(Locatable.Empty)
        {
            Content = content;
        }

        protected Document(ILocatable src, C content)
            : base(src)
        {
            Content = content;
        }

        [MethodImpl(Inline)]
        D WithContent(C content)
        {
            Content = content;
            return (D)this;
        }

        public virtual D Load(C content)
            => new D().WithContent(content);

        public override string Format()
            => Content.Format();

        public override string ToString()
            => Format();
    }

    public abstract class Document<D,C,L> : Document<D,C>, IDocument<D,C,L>
        where D : Document<D,C,L>, new()
        where C : struct, ITextual
        where L : struct, ILocatable
    {
        public static D load(L location)
            => new D().Load(location);

        protected Document(L src, C content)
            : base(src, content)
        {
            Source = src;
        }

        protected Document(C content)
            : base(content)
        {
            Source = default;
        }

        public new L Source {get;}

        public abstract D Load(L src);

        public sealed override D Load(ILocatable src)
            => Load((L)src);
    }
}