//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public class RuleCells
        {
            public readonly CellTables CellTables;

            public readonly string Description;

            internal RuleCells(CellTables tables, string desc)
            {
                CellTables = tables;
                Description = desc;
            }

            RuleCells()
            {
                CellTables = null;
                Description = EmptyString;
            }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => CellTables.TableCount;
            }

            public ref readonly CellTable this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref CellTables[i];
            }

            public ref readonly CellTable this[int i]
            {
                [MethodImpl(Inline)]
                get => ref CellTables[i];
            }

            public string Format()
                => Description;

            public override string ToString()
                => Format();

            public static RuleCells Empty => new();
        }
   }
}