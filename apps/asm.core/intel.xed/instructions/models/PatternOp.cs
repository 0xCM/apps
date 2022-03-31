//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        public struct PatternOp : IComparable<PatternOp>
        {
            public uint PatternId;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAttribs Attribs;

            public @string SourceExpr;

            public PatternOp()
            {
                PatternId = 0u;
                Index =z8;
                Name = OpName.Empty;
                Kind = 0;
                Attribs = OpAttribs.Empty;
                SourceExpr = EmptyString;
            }

            public Hex32 OpId
            {
                [MethodImpl(Inline)]
                get => PatternId << 8 | Index;
            }

            [MethodImpl(Inline)]
            public PatternOpInfo Describe()
                => describe(this);

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

            public bool IsBaseReg
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Base;
            }

            public bool IsIndexReg
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Index;
            }

            public bool IsSegReg
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Seg;
            }

            public bool IsMem
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Mem;
            }

            public bool IsImm
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Imm;
            }

            public bool IsPtr
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Ptr;
            }

            public bool IsDisp
            {
                [MethodImpl(Inline)]
                get => Kind == OpKind.Disp;
            }

            public bool HasPtrWidth
            {
                [MethodImpl(Inline)]
                get => PtrWidth(out _);
            }

            public bool HasElementType
            {
                [MethodImpl(Inline)]
                get => ElementType.IsNonEmpty;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => XedPatterns.nonterm(this, out _);
            }

            public bool HasOpWidth
            {
                [MethodImpl(Inline)]
                get => OpWidth(out _);
            }

            [MethodImpl(Inline)]
            public bool Nonterminal(out Nonterminal dst)
                => XedPatterns.nonterm(this, out dst);

            [MethodImpl(Inline)]
            public bool RegLiteral(out Register dst)
                => XedPatterns.reglit(this, out dst);

            [MethodImpl(Inline)]
            public bool OpWidth(out OpWidth dst)
                => XedPatterns.opwidth(this, out dst);

            [MethodImpl(Inline)]
            public bool PtrWidth(out PointerWidthKind dst)
                => XedPatterns.ptrwidth(this, out dst);

            public ElementType ElementType
            {
                [MethodImpl(Inline)]
                get => etype(this);
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(PatternOp src)
                => OpId.CompareTo(src.OpId);

            [MethodImpl(Inline)]
            static ElementType etype(in PatternOp op)
            {
                var dst = ElementType.Empty;
                if(op.Attribs.Search(OpClass.ElementType, out var attrib))
                    dst = attrib.AsElementType();
                return dst;
            }

            public static PatternOp Empty => new();
        }
    }
}