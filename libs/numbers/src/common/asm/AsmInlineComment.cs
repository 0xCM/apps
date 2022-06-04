//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmInlineComment : IAsmSourcePart
    {
        public static AsmInlineComment array(ReadOnlySpan<byte> src)
            => new AsmInlineComment(AsmCommentMarker.Hash, HexFormatter.array(src));

        public AsmCommentMarker Marker {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public AsmInlineComment(AsmCommentMarker marker, string content)
        {
            Marker = marker;
            Content = content;
        }

        public AsmCellKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.InlineComment;
        }

        public string Format()
            => text.empty(Content) ? EmptyString : string.Format("{0} {1}", (char)Marker, Content);

        public override string ToString()
            => Format();

        public static implicit operator string(AsmInlineComment src)
            => src.Format();

        public static AsmInlineComment Empty
        {
            [MethodImpl(Inline)]
            get => new AsmInlineComment(0,EmptyString);
        }
    }
}