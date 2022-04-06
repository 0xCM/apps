//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct ImmSeg
        {
            public readonly ImmSpec Spec;

            public readonly byte Index;

            [MethodImpl(Inline)]
            public ImmSeg(byte index, ImmSpec kind)
            {
                Spec = kind;
                Index = index;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Index == 0 ? FieldKind.UIMM0 : FieldKind.UIMM1;
            }

            [MethodImpl(Inline)]
            public ImmSeg WithIndex(byte index)
                => new ImmSeg(index,Spec);

            public byte Width
            {
                [MethodImpl(Inline)]
                get => (byte)((byte)Spec * 8);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Spec == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Spec != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator ushort(ImmSeg src)
                => core.u16(src);

            [MethodImpl(Inline)]
            public static explicit operator ImmSeg(ushort src)
                => core.@as<ushort,ImmSeg>(src);

            public static ImmSeg Empty => default;
        }
    }
}