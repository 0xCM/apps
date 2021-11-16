//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SourceCode : ILangSource
    {
        public LangKind LangKind {get;}

        public TextBlock Text {get;}

        [MethodImpl(Inline)]
        public SourceCode(LangKind kind, TextBlock text)
        {
            LangKind = kind;
            Text = text;
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();
    }
}