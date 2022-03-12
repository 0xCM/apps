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
        [Record(TableId)]
        public struct RulePatternInfo : IEquatable<RulePatternInfo>, IComparable<RulePatternInfo>
        {
            public const string TableId = "xed.rules.patterns";

            public const byte FieldCount = 6;

            public uint Seq;

            public uint InstId;

            public Hash32 Hash;

            public IClass Class;

            public OpCodeKind OpCodeKind;

            public TextBlock BodyExpr;

            public override int GetHashCode()
                => (int)Hash;

            public bool Equals(RulePatternInfo src)
                => BodyExpr.Equals(src.BodyExpr);

            public int CompareTo(RulePatternInfo src)
            {
                var i = ((ushort)Class).CompareTo(((ushort)src.Class));
                if(i == 0)
                    i = BodyExpr.CompareTo(src.BodyExpr);
                return i;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,6,12,24,16,1};
        }
    }
}