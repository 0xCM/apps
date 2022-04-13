//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RowSpec
        {
            public readonly ushort TableId;

            public readonly RuleTableKind TableKind;

            public readonly RuleSig Sig;

            public readonly ushort RowIndex;

            public readonly Index<CellKey> Keys;

            public readonly Index<CellSpec> Cells;

            public readonly ushort ColCount;

            [MethodImpl(Inline)]
            public RowSpec(RuleSig sig, ushort tid, ushort rix, CellKey[] keys, CellSpec[] cells)
            {
                TableKind = sig.TableKind;
                Sig = sig;
                TableId = tid;
                RowIndex = rix;
                Keys = keys;
                Cells = cells;
                ColCount = (ushort)Require.equal(keys.Length, cells.Length);
            }

            [MethodImpl(Inline)]
            public ref readonly CellSpec Cell(ushort i)
                => ref Cells[i];

            [MethodImpl(Inline)]
            public ref readonly CellKey Key(ushort i)
                => ref Keys[i];

            public string Format()
                => CellRender.expression(this);

            public override string ToString()
                => Format();
        }
    }
}