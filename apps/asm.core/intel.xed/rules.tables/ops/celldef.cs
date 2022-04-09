//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        partial struct TableCalcs
        {
            // public static byte celldefs(in TableSpec table, Index<CellSpec> src, LogicClass logic, ushort row, ref byte k, Span<CellDef> dst)
            // {
            //     var i0 = k;
            //     for(var j=0; j<src.Count; j++, k++)
            //         seek(dst,k) = celldef(new CellKey(table.TableKind, table.TableId, row, logic, k), src[j]);
            //     return (byte)(k - i0);
            // }

            // public static CellDef celldef(in CellKey key, in CellSpec src)
            // {
            //     Require.invariant(key.IsNonEmpty);
            //     var type = celltype(src);
            //     return new CellDef(key, src.Field, src.Operator, type, value(src), src.Data);
            // }
        }
    }
}