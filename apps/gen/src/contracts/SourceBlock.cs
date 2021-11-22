//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SourceBlock
    {
        public TextBlock Content {get;}

        public SourceKind Kind {get;}

        public SourceBlock(TextBlock content, SourceKind kind)
        {
            Content = content;
            Kind = kind;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();
    }
}