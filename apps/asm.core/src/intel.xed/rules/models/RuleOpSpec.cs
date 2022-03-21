//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedRules
    {
        public struct RuleOpSpec
        {
            public byte Index;

            public RuleOpName Name;

            public RuleOpKind Kind;

            public RuleOpAttribs Attribs;

            public @string Expression;

            public string Format()
                => text.format("{0}:{1}", Name, Attribs.Delimit(Chars.Colon).Format());

            public override string ToString()
                => Format();

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name != 0;
            }

            public bool IsReg
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Reg || Kind == RuleOpKind.Base || Kind == RuleOpKind.Index || Kind == RuleOpKind.Seg;
            }

            public bool IsBaseReg
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Base;
            }

            public bool IsIndexReg
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Index;
            }

            public bool IsSegReg
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Seg;
            }

            public bool IsMem
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Mem;
            }

            public bool IsImm
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Imm;
            }

            public bool IsPtr
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Ptr;
            }

            public bool IsDisp
            {
                [MethodImpl(Inline)]
                get => Kind == RuleOpKind.Disp;
            }

            public bool HasOpWidth
            {
                [MethodImpl(Inline)]
                get => OpWidthKind != 0;
            }

            public bool HasPtrWidth
            {
                [MethodImpl(Inline)]
                get => PtrWidthKind != 0;
            }

            public bool HasElementType
            {
                [MethodImpl(Inline)]
                get => ElementType.IsNonEmpty;
            }

            public OpWidthCode OpWidthKind
            {
                [MethodImpl(Inline)]
                get => opwidth(this);
            }

            public ushort OpWidth
            {
                [MethodImpl(Inline)]
                get => bitwidth(OpWidthKind);
            }

            public PointerWidthKind PtrWidthKind
            {
                [MethodImpl(Inline)]
                get => ptrwidth(this);
            }

            public ushort PtrWidth
            {
                [MethodImpl(Inline)]
                get => bitwidth(PtrWidthKind);
            }

            public ElementType ElementType
            {
                [MethodImpl(Inline)]
                get => etype(this);
            }

            public ushort ElementWidth
            {
                [MethodImpl(Inline)]
                get => bitwidth(OpWidthKind, ElementType);
            }

            [MethodImpl(Inline)]
            static PointerWidthKind ptrwidth(in RuleOpSpec op)
            {
                var dst = PointerWidthKind.INVALID;
                if(op.Attribs.Search(RuleOpClass.PtrWidth, out var attrib))
                    dst = attrib.AsPtrWidth();
                return dst;
            }

            [MethodImpl(Inline)]
            static OpWidthCode opwidth(in RuleOpSpec op)
            {
                var dst = OpWidthCode.INVALID;
                if(op.Attribs.Search(RuleOpClass.OpWidth, out var attrib))
                    dst = attrib.AsOpWidth();
                return dst;
            }

            [MethodImpl(Inline)]
            static ElementType etype(in RuleOpSpec op)
            {
                var dst = ElementType.Empty;
                if(op.Attribs.Search(RuleOpClass.ElementType, out var attrib))
                    dst = attrib.AsElementType();
                return dst;
            }

            public static RuleOpSpec Empty => default;
        }
    }
}