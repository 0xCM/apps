//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum SegSpecKind
        {
            None,

            Bitfield,

            Imm,

            Disp,
        }

        public readonly struct SegSpec
        {
            public readonly SegSpecKind Kind;

            public readonly asci16 Pattern;

            public SegSpec(SegSpecKind kind, string pattern, bool check)
            {
                Require.invariant(pattern.Length <= asci16.Size);
                Kind = kind;
                Pattern = pattern;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, string pattern)
            {
                Kind = kind;
                Pattern = pattern;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char pattern)
            {
                Kind = kind;
                var dst = asci16.Null;
                Pattern = new asci16(pattern);
            }

            public string Format()
                => Pattern.Format();

            public override string ToString()
                => Format();
        }
    }
}