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
        partial class RuleGrids
        {
            [MethodImpl(Inline)]
            public static LogicCell<T> logical<T>(CellKey key, T value)
                where T : unmanaged,  ILogicValue<T>, IEquatable<T>, ILogicOperand<T>
                    => new LogicCell<T>(key,value);

            [MethodImpl(Inline)]
            public static LogicValue<T> value<T>(LogicDataKind kind, byte width, T data)
                where T : unmanaged
                    => new LogicValue<T>(kind,width,data);

            public static Index<GridCell> cells(CellRow src)
            {
                var count = src.CellCount;
                var dst = alloc<GridCell>(count);
                for(var i=0; i< count; i++)
                {
                    ref readonly var f = ref src[i];
                    seek(dst,i) = new GridCell(f.TableIndex, f.RowIndex, f.CellIndex, f.Field, XedFields.field(f.Field).Size);

                }
                return dst;
            }
        }
    }
}