//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public struct OpSpec : IComparable<OpSpec>
        {
            public uint PatternId;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAttribs Attribs;

            public @string Expression;

            public OpSpec()
            {
                PatternId = 0u;
                Index =z8;
                Name = 0;
                Kind = 0;
                Attribs = OpAttribs.Empty;
                Expression = EmptyString;
            }

            public Hex32 OpId
            {
                [MethodImpl(Inline)]
                get => PatternId << 8 | Index;
            }

            public string Format()
                => XedRender.format(this);

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
                get => PtrWidthKind != 0;
            }

            public bool HasElementType
            {
                [MethodImpl(Inline)]
                get => ElementType.IsNonEmpty;
            }

            public OpWidth OpWidth
            {
                [MethodImpl(Inline)]
                get => opwidth(this);
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

            [MethodImpl(Inline)]
            public int CompareTo(OpSpec src)
                => OpId.CompareTo(src.OpId);

            [MethodImpl(Inline)]
            static PointerWidthKind ptrwidth(in OpSpec op)
            {
                var dst = PointerWidthKind.INVALID;
                if(op.Attribs.Search(OpClass.PtrWidth, out var attrib))
                    dst = attrib.AsPtrWidth();
                return dst;
            }

            [MethodImpl(Inline)]
            static OpWidth opwidth(in OpSpec op)
            {
                if(op.Attribs.Search(OpClass.OpWidth, out var attrib))
                    return attrib.AsOpWidth();
                else

                    return XedModels.OpWidth.Empty;
            }

            [MethodImpl(Inline)]
            static ElementType etype(in OpSpec op)
            {
                var dst = ElementType.Empty;
                if(op.Attribs.Search(OpClass.ElementType, out var attrib))
                    dst = attrib.AsElementType();
                return dst;
            }

            public static OpSpec Empty => new();
        }
    }
}