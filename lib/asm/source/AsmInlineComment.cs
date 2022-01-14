//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmInlineComment : IAsmSourcePart
    {
        public AsmCommentMarker Marker {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public AsmInlineComment(AsmCommentMarker marker, string content)
        {
            Marker = marker;
            Content = content;
        }

        public AsmPartKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.InlineComment;
        }

        public string Format()
            => text.empty(Content) ? EmptyString : string.Format("{0} {1}", (char)Marker, Content);

        public override string ToString()
            => Format();

        public static implicit operator string(AsmInlineComment src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmInlineComment src)
            => asm.cell(src.Format(), src.PartKind);

        public static AsmInlineComment Empty
        {
            [MethodImpl(Inline)]
            get => new AsmInlineComment(0,EmptyString);
        }
    }
}