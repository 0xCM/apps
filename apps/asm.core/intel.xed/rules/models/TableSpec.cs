//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct TableSpec
        {
            public readonly RuleSig Sig;

            public readonly Index<RowSpec> Rows;

            [MethodImpl(Inline)]
            public TableSpec(RowSpec[] rows)
            {
                if(rows.Length != 0)
                {
                    Rows = rows;
                    Sig = Rows.First.Sig;
                }
                else
                {
                    Rows = sys.empty<RowSpec>();
                    Sig = RuleSig.Empty;
                }
            }

            public string Name
            {
                [MethodImpl(Inline)]
                get => Sig.ShortName;
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Sig.TableKind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Sig.IsEmpty;
            }

            public uint RowCount
            {
                [MethodImpl(Inline)]
                get => Rows.Count;
            }

            public ref readonly RowSpec this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref readonly RowSpec this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public string Format()
                => CellRender.expressions(this);

            public override string ToString()
                => Format();

            public static TableSpec Empty => new TableSpec(sys.empty<RowSpec>());

            [MethodImpl(Inline)]
            public static implicit operator TableSpec(RowSpec[] src)
                => new TableSpec(src);

            [MethodImpl(Inline)]
            public static implicit operator TableSpec(Index<RowSpec> src)
                => new TableSpec(src);

            [MethodImpl(Inline)]
            public static implicit operator Index<RowSpec>(TableSpec src)
                => src.Rows;
        }
    }
}