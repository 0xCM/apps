//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct SegSpec
        {
            readonly byte KindData;

            public readonly SegSpecKind Kind;

            public readonly asci16 Pattern;

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, ReadOnlySpan<char> pattern)
            {
                Kind = kind;
                Asci.encode(pattern, out Pattern);
                KindData = 0;
            }

            [MethodImpl(Inline)]
            public SegSpec(ImmSpec kind, ReadOnlySpan<char> pattern)
            {
                Kind = SegSpecKind.Imm;
                Asci.encode(pattern, out Pattern);
                KindData = (byte)kind;
            }

            [MethodImpl(Inline)]
            public SegSpec(DispSpec kind, ReadOnlySpan<char> pattern)
            {
                Kind = SegSpecKind.Disp;
                Asci.encode(pattern, out Pattern);
                KindData = (byte)kind;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0);
                KindData = 0;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0, c1);
                KindData = 0;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1, char c2)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0, c1, c2);
                KindData = 0;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1, char c2, char c3)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0, c1, c2, c3);
                KindData = 0;
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
                => Pattern.Format();

            public override string ToString()
                => Format();

            public static SegSpec Empty => default;
        }
    }
}