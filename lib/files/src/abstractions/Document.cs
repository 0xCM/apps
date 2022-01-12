//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Document<D> : IDocument<D>
        where D : Document<D>, new()
    {
        public ILocatable Location {get; protected set;}

        protected Document(ILocatable src)
        {
            Location = src;
        }

        protected Document()
        {
            Location = Locatable.Empty;
        }

        public abstract D Load();

        public abstract string Format();
    }

    public abstract class Document<D,C> : Document<D>, IDocument<D,C>
        where D : Document<D,C>, new()
    {
        [MethodImpl(Inline)]
        public static D load(C content)
        {
            var doc = new D();
            doc.Content = content;
            return doc;
        }

        public C Content {get; protected set;}

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
            => Content.ToString();

        public override string ToString()
            => Format();
    }

    public abstract class Document<D,C,L> : Document<D,C>, IDocument<D,C,L>
        where D : Document<D,C,L>, new()
        where L : ILocatable
    {
        public static D load(L location)
        {
            var doc = new D();
            doc.Location = location;
            return doc.Load();
        }

        protected Document(L src, C content)
            : base(src, content)
        {
            Location = src;
        }

        protected Document(C content)
            : base(content)
        {
            Location = default;
        }

        public new L Location {get; protected set;}
    }
}