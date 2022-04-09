//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct TableSpec : IComparable<TableSpec>
        {
            public readonly uint TableId;

            public readonly RuleSig Sig;

            public readonly Index<RowSpec> Rows;

            [MethodImpl(Inline)]
            public TableSpec(in RuleSig sig, RowSpec[] rows)
            {
                TableId = 0u;
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            public TableSpec(uint id, in RuleSig sig, RowSpec[] rows)
            {
                TableId = id;
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            TableSpec(uint id)
            {
                TableId = id;
                Sig = RuleSig.Empty;
                Rows = sys.empty<RowSpec>();
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

            public ref RowSpec this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref RowSpec this[uint i]
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

            public TableSpec Merge(in TableSpec src)
                => new TableSpec(Require.equal(Sig,src.Sig), Rows.Append(src.Rows));

            [MethodImpl(Inline)]
            public TableSpec WithId(uint id)
                => new TableSpec(id, Sig, Rows);

            public ReadOnlySpan<TextLine> Lines()
                => Format().Lines(trim:false);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(TableSpec src)
                => Sig.CompareTo(src.Sig);

            public static TableSpec Empty => new TableSpec(0);
        }
    }
}