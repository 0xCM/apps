//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmComment : IAsmSourcePart
    {
        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public AsmComment(TextBlock text)
            => Content = text;

        public AsmPartKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.Comment;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content.IsNonEmpty ? string.Format("# {0}", Content) : EmptyString;

        public override string ToString()
            => Format();

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

        public static AsmComment Empty
        {
            [MethodImpl(Inline)]
            get => new AsmComment(TextBlock.Empty);
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmComment(string src)
            => new AsmComment(src);

        [MethodImpl(Inline)]
        public static implicit operator string(AsmComment src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmComment src)
            => asm.cell(src.Format(), src.PartKind);
    }
}