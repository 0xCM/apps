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
        public readonly record struct FieldSeg
        {
            public const uint MetaWidth = 8 + SegVar.MetaWidth;

            public static FieldSeg literal(FieldKind field, byte n, byte value)
                => new FieldSeg(field, SegVar.literal(n,value));

            public static FieldSeg literal(FieldKind field, BitNumber<byte> value)
                => new FieldSeg(field, SegVar.literal(value));

            public static FieldSeg symbolic(FieldKind field, string spec)
                => new FieldSeg(field, SegVar.parse(spec));

            [MethodImpl(Inline)]
            public static FieldSeg symbolic(FieldKind field, char c0)
                => new FieldSeg(field, c0);

            [MethodImpl(Inline)]
            public static FieldSeg symbolic(FieldKind field, char c0, char c1)
                => new FieldSeg(field, new SegVar(c0, c1));

            public static FieldSeg symbolic(string spec)
                => new FieldSeg(0, SegVar.parse(spec));

            public static FieldSeg literal(FieldKind field, string data)
            {
                XedParsers.bitnumber(data, out byte n, out byte value);
                return literal(field, n, value);
            }

            public readonly FieldKind Field;

            public readonly SegVar Seg;

            [MethodImpl(Inline)]
            public FieldSeg(SegVar seg, FieldKind field)
            {
                Seg = seg;
                Field = field;
            }

            [MethodImpl(Inline)]
            public FieldSeg(FieldKind field, SegVar seg)
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

            public static FieldSeg Empty => default;
        }
    }
}