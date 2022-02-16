//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmBlockSpec : IAsmSourcePart
    {
        public AsmComment Comment {get;}

        public AsmBlockLabel Label {get;}

        public Index<AsmInstruction> Content {get;}

        [MethodImpl(Inline)]
        public AsmBlockSpec(AsmComment comment, AsmBlockLabel label, Index<AsmInstruction> content)
        {
            Comment = comment;
            Label = label;
            Content = content;
        }

        public AsmPartKind PartKind
            => AsmPartKind.Block;

        public string Format()
            => AsmRender.spec(this);

        public override string ToString()
            => Format();
    }
}