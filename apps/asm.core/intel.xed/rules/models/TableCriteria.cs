//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct TableCriteria : IComparable<TableCriteria>
        {
            public readonly uint TableId;

            public readonly RuleSig Sig;

            public readonly Index<RowCriteria> Rows;

            [MethodImpl(Inline)]
            public TableCriteria(in RuleSig sig, RowCriteria[] rows)
            {
                TableId = 0u;
                Require.invariant(sig.IsNonEmpty);
                Require.invariant(rows.Length != 0);
                Sig = sig;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            public TableCriteria(uint id, in RuleSig sig, RowCriteria[] rows)
            {
                TableId = id;
                Require.invariant(sig.IsNonEmpty);
                Require.invariant(rows.Length != 0);
                Sig = sig;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            TableCriteria(uint id)
            {
                TableId = id;
                Sig = RuleSig.Empty;
                Rows = sys.empty<RowCriteria>();
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Sig.TableKind;
            }

            public string TableName
            {
                [MethodImpl(Inline)]
                get => Sig.ShortName;
            }

            public bool IsEncTable
            {
                [MethodImpl(Inline)]
                get => Sig.IsEncTable;
            }

            public bool IsDecTable
            {
                [MethodImpl(Inline)]
                get => Sig.IsDecTable;
            }

            public uint RowCount
            {
                [MethodImpl(Inline)]
                get => Rows.Count;
            }

            public ref RowCriteria this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref RowCriteria this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Sig.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Sig.IsNonEmpty;
            }

            public TableCriteria Merge(in TableCriteria src)
                => new TableCriteria(Require.equal(Sig, src.Sig), Rows.Append(src.Rows));

            [MethodImpl(Inline)]
            public TableCriteria WithId(uint id)
                => new TableCriteria(id, Sig, Rows);

            public ReadOnlySpan<TextLine> Lines()
                => Format().Lines(trim:false);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(TableCriteria src)
                => Sig.CompareTo(src.Sig);

            public static TableCriteria Empty => new TableCriteria(0);
        }
    }
}