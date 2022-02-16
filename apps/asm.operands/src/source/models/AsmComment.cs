//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmComment : IAsmSourcePart
    {
        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public AsmComment(TextBlock text)
            => Content = text;

        AsmPartKind IAsmSourcePart.PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.Comment;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => AsmRender.comment(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmComment(string src)
            => new AsmComment(src);

        [MethodImpl(Inline)]
        public static implicit operator string(AsmComment src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmComment src)
            => AsmCell.define(src.Format(), AsmPartKind.Comment);

        public static AsmComment Empty
        {
            [MethodImpl(Inline)]
            get => new AsmComment(TextBlock.Empty);
        }
    }
}