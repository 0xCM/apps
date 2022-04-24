//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct SegField
        {
            public static SegField literal(FieldKind field, byte n, byte value)
                => new SegField(SegVar.literal(n,value), field);

            public static SegField literal(FieldKind field, string data)
            {
                XedParsers.bitnumber(data, out byte n, out byte value);
                return literal(field, n, value);
            }

            public readonly SegVar Seg;

            public readonly FieldKind Field;

            [MethodImpl(Inline)]
            public SegField(SegVar seg, FieldKind field)
            {
                Seg = seg;
                Field = field;
            }

            public string Format()
            {
                var dst = EmptyString;
                if(Field == 0)
                    dst = Seg.Format();
                else
                    dst = string.Format("{0}[{1}]", XedRender.format(Field), Seg);
                return dst;
            }

            public override string ToString()
                => Format();

            public static SegField Empty => default;
        }
    }
}