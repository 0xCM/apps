//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmCell : IAsmSourcePart, INullity
    {
        [MethodImpl(Inline)]
        public static AsmCell define(string content, AsmCellKind kind)
            => new AsmCell(kind, content);

        public @string Content {get;}

        public AsmCellKind PartKind {get;}

        [MethodImpl(Inline)]
        public AsmCell(AsmCellKind kind, string content)
        {
            Content = content;
            PartKind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();
    }
}