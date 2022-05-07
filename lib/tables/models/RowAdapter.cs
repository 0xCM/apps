//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Tables;

    /// <summary>
    /// Defines a row over a specified record type
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    public struct RowAdapter
    {
        public readonly ClrRecordFields Fields
        {
            [MethodImpl(Inline)]
            get => Row.Fields;
        }

        internal uint Index;

        internal dynamic Source;

        internal DynamicRow Row;

        public readonly Type RowType;

        [MethodImpl(Inline)]
        internal RowAdapter(Type type, ClrRecordFields fields)
        {
            RowType = type;
            Source = type;
            Index = 0;
            Row = api.dynarow(fields);
        }

        [MethodImpl(Inline)]
        public RowAdapter Adapt<T>(in T src)
            where T : struct
                => RecordFormatter.adapt<T>(src, ref this);

        public readonly DynamicRow Adapted
        {
            [MethodImpl(Inline)]
            get => Row;
        }

        public readonly Span<dynamic> Cells
        {
            [MethodImpl(Inline)]
            get => Row.Cells;
        }

        public readonly uint ColumnCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }
    }
}