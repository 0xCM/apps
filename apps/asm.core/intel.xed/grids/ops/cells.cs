//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedGrids
    {
        [MethodImpl(Inline)]
        public static LogicCell<T> logical<T>(CellKey key, T value)
            where T : unmanaged,  ILogicValue<T>, IEquatable<T>, ILogicOperand<T>
                => new LogicCell<T>(key,value);

        [MethodImpl(Inline)]
        public static LogicValue<T> value<T>(LogicDataKind kind, DataSize size, T data)
            where T : unmanaged
                => new LogicValue<T>(kind,size,data);

        [MethodImpl(Inline)]
        public static GridCell cell(in RuleCell rc)
            => new GridCell(rc.Logic, rc.TableIndex, rc.RowIndex, rc.CellIndex, rc.Field, ColType.field(rc.Field), XedFields.field(rc.Field).Size);

        public static Index<GridCell> cells(in CellRow src)
        {
            var count = src.CellCount;
            var dst = alloc<GridCell>(count);
            for(var i=0; i< count; i++)
                seek(dst,i) = cell(src[i]);
            return dst;
        }
    }
}