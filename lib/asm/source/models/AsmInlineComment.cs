//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct AsmInlineComment : IAsmSourcePart
    {
        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out AsmInlineComment dst)
        {
            var count = src.Length;
            var marker = AsmCommentMarker.None;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                switch(c)
                {
                    case (char)AsmCommentMarker.Semicolon:
                    case (char)AsmCommentMarker.Hash:
                        if(marker == 0)
                            marker = (AsmCommentMarker)c;
                        else
                            buffer.Append(c);
                    break;
                    default:
                        if(marker !=0)
                            buffer.Append(c);
                    break;
                }
            }
            var found = marker != 0;
            if(found)
                dst = new AsmInlineComment(marker, buffer.Emit());
            else
                dst = AsmInlineComment.Empty;
            return found;
        }

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
            => AsmCell.define(src.Format(), src.PartKind);

        public static AsmInlineComment Empty
        {
            [MethodImpl(Inline)]
            get => new AsmInlineComment(0,EmptyString);
        }
    }
}