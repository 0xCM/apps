//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
}