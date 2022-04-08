//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellTableSpec : IComparable<CellTableSpec>
        {
            public readonly uint TableId;

            public readonly RuleSig Sig;

            public readonly Index<CellRowSpec> Rows;

            [MethodImpl(Inline)]
            public CellTableSpec(in RuleSig sig, CellRowSpec[] rows)
            {
                TableId = 0u;
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            public CellTableSpec(uint id, in RuleSig sig, CellRowSpec[] rows)
            {
                TableId = id;
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            CellTableSpec(uint id)
            {
                TableId = id;
                Sig = RuleSig.Empty;
                Rows = sys.empty<CellRowSpec>();
            }

            public static CellTableSpec Empty => new CellTableSpec(0);


            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Sig.TableKind;
            }

            public string ShortName
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

            public ref CellRowSpec this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref CellRowSpec this[uint i]
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

            public CellTableSpec Merge(in CellTableSpec src)
                => new CellTableSpec(Require.equal(Sig,src.Sig), Rows.Append(src.Rows));

            [MethodImpl(Inline)]
            public CellTableSpec WithId(uint id)
                => new CellTableSpec(id, Sig, Rows);

            public ReadOnlySpan<TextLine> Lines()
                => Format().Lines(trim:false);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(CellTableSpec src)
                => Sig.CompareTo(src.Sig);
        }
    }
}