//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct ImmField
        {
            public readonly ImmFieldKind Kind;

            public readonly byte Index;

            [MethodImpl(Inline)]
            public ImmField(byte index, ImmFieldKind kind)
            {
                Kind = kind;
                Index = index;
            }

            [MethodImpl(Inline)]
            public ImmField WithIndex(byte index)
                => new ImmField(index,Kind);

            public byte Width
            {
                [MethodImpl(Inline)]
                get => (byte)((byte)Kind * 8);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator ushort(ImmField src)
                => core.u16(src);

            [MethodImpl(Inline)]
            public static explicit operator ImmField(ushort src)
                => core.@as<ushort,ImmField>(src);

            public static ImmField Empty => default;
        }
    }
}