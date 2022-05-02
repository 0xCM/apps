//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public record struct TableStats : IComparable<TableStats>
        {
            public const string TableId = "rules.tables.stats";

            public const byte FieldCount = 9;

            public uint Seq;

            public RuleTableKind Kind;

            public RuleName Rule;

            public ushort Rows;

            public DataSize TableSize;

            public DataSize MaxRowSize;

            public byte MaxCols;

            public DataSize UniformTableSize;

            public bit Homogenous;

            [MethodImpl(Inline)]
            public TableStats(uint seq,RuleSig rule, ushort rows, DataSize tsz, DataSize mrsz, byte maxcc)
            {
                Seq = seq;
                Rule = rule.TableName;
                Kind = rule.TableKind;
                Rows = rows;
                TableSize = tsz;
                MaxRowSize = mrsz;
                MaxCols = maxcc;
                UniformTableSize = new DataSize(mrsz.Packed*rows, mrsz.Aligned*rows);
                Homogenous = TableSize == UniformTableSize;
            }

            public RuleSig Sig
            {
                [MethodImpl(Inline)]
                get => new RuleSig(Kind,Rule);
            }

            public int CompareTo(TableStats src)
                => Sig.CompareTo(src.Sig);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,6,32,8,12,12,8,16,12};
        }
    }
}