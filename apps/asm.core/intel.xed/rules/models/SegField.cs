//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly record struct SegField
        {
            public const uint MetaWidth = 8 + SegVar.MetaWidth;

            public static SegField literal(FieldKind field, byte n, byte value)
                => new SegField(field, SegVar.literal(n,value));

            public static SegField literal(FieldKind field, BitNumber<byte> value)
                => new SegField(field, SegVar.literal(value));

            public static SegField symbolic(FieldKind field, string spec)
                => new SegField(field, SegVar.parse(spec));

            [MethodImpl(Inline)]
            public static SegField symbolic(FieldKind field, char c0)
                => new SegField(field, c0);

            [MethodImpl(Inline)]
            public static SegField symbolic(FieldKind field, char c0, char c1)
                => new SegField(field, new SegVar(c0, c1));

            public static SegField symbolic(string spec)
                => new SegField(0, SegVar.parse(spec));

            public static SegField literal(FieldKind field, string data)
            {
                XedParsers.bitnumber(data, out byte n, out byte value);
                return literal(field, n, value);
            }

            public readonly FieldKind Field;

            public readonly SegVar Seg;

            [MethodImpl(Inline)]
            public SegField(SegVar seg, FieldKind field)
            {
                Seg = seg;
                Field = field;
            }

            [MethodImpl(Inline)]
            public SegField(FieldKind field, SegVar seg)
            {
                Field = field;
                Seg = seg;
            }

            [MethodImpl(Inline)]
            public bool IsLiteral()
                => Seg.IsLiteral();

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static SegField Empty => default;
        }
    }
}