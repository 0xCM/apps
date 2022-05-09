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
    public struct RowAdapter<T>
        where T : struct
    {
        public readonly ClrRecordFields Fields
        {
            [MethodImpl(Inline)]
            get => Row.Fields;
        }

        internal uint Index;

        internal T Source;

        internal DynamicRow<T> Row;

        [MethodImpl(Inline)]
        internal RowAdapter(ClrRecordFields fields)
        {
            Source = default;
            Index = 0;
            Row = api.dynarow<T>(fields);
        }

        [MethodImpl(Inline)]
        public RowAdapter<T> Adapt(in T src)
            => api.adapt(src, ref this);

        public readonly DynamicRow<T> Adapted
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