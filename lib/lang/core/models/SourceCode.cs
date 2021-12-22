//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SourceCode : ISourceCode<TextBlock>
    {
        public LangKind LangKind {get;}

        public TextBlock Document {get;}

        [MethodImpl(Inline)]
        public SourceCode(LangKind kind, TextBlock text)
        {
            LangKind = kind;
            Document = text;
        }

        public string Format()
            => Document;

        public override string ToString()
            => Format();
    }
}