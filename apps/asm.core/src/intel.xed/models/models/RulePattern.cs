//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId)]
        public struct RulePattern : IEquatable<RulePattern>, IComparable<RulePattern>
        {
            public const string TableId = "xed.rules.patterns";

            public const byte FieldCount = 5;

            public uint Seq;

            public Hash32 Hash;

            public IClass Class;

            public OpCodeKind OpCodeKind;

            public TextBlock Expression;

            public override int GetHashCode()
                => (int)Hash;

            public bool Equals(RulePattern src)
                => Expression.Equals(src.Expression);

            public int CompareTo(RulePattern src)
            {
                var i = ((ushort)Class).CompareTo(((ushort)src.Class));
                if(i == 0)
                    i = Expression.CompareTo(src.Expression);
                return i;
            }

             public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,24,16,1};
        }
    }
}