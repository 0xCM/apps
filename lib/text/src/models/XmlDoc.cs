//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct XmlDoc : ITextual
    {
        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public XmlDoc(TextBlock content)
        {
            Content = content;
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator XmlDoc(string src)
            => new XmlDoc(src);
    }
}