//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.SegSpecLiterals;

    partial class XedRules
    {
        public readonly struct SegSpecs
        {
            public static SegSpec Sib => new SegSpec(SegSpecKind.Bitfield, ss_iii_bbb);
        }

        public readonly struct SegSpec
        {
            public readonly SegSpecKind Kind;

            public readonly asci16 Pattern;

            public SegSpec(SegSpecKind kind, ReadOnlySpan<char> pattern, bool check)
            {
                Require.invariant(pattern.Length <= asci16.Size);
                Kind = kind;
                Asci.encode(pattern, out Pattern);
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, ReadOnlySpan<char> pattern)
            {
                Kind = kind;
                Asci.encode(pattern, out Pattern);
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0);
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0, c1);
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1, char c2)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0, c1, c2);
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1, char c2, char c3)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(c0, c1, c2, c3);
            }

            public string Format()
                => Pattern.Format();

            public override string ToString()
                => Format();
        }
    }
}