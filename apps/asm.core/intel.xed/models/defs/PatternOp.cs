//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        public struct PatternOp : IComparable<PatternOp>
        {
            public uint PatternId;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAttribs Attribs;

            public @string SourceExpr;

            public OpWidthSpec Width;

            public PatternOp()
            {
                PatternId = 0u;
                Index = z8;
                Name = OpName.Empty;
                Kind = 0;
                Attribs = OpAttribs.Empty;
                SourceExpr = EmptyString;
                Width = OpWidthSpec.Empty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsNonEmpty;
            }

            public bool IsReg
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Reg || Kind == OpKind.Base || Kind == OpKind.Index || Kind == OpKind.Seg;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => XedPatterns.nonterm(this, out _);
            }

            [MethodImpl(Inline)]
            public bool Nonterminal(out Nonterminal dst)
                => XedPatterns.nonterm(this, out dst);

            [MethodImpl(Inline)]
            public bool RegLiteral(out Register dst)
                => XedPatterns.reglit(this, out dst);

            [MethodImpl(Inline)]
            public bool WidthCode(out OpWidthCode dst)
                => XedPatterns.widthcode(this, out dst);

            [MethodImpl(Inline)]
            public bool ElementType(out ElementType dst)
                => XedPatterns.etype(this, out dst);

            [MethodImpl(Inline)]
            public bool Visibility(out Visibility dst)
                => XedPatterns.visibility(this, out dst);

            [MethodImpl(Inline)]
            public bool Action(out OpAction dst)
                => XedPatterns.action(this, out dst);

            [MethodImpl(Inline)]
            public bool Scale(out MemoryScale dst)
                => XedPatterns.scale(this, out dst);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(PatternOp src)
            {
                var result = PatternId.CompareTo(src.PatternId);
                if(result == 0)
                    result = Index.CompareTo(src.Index);
                return result;
            }

            public static PatternOp Empty => new();
        }
    }
}