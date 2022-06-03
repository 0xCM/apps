//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines the content of a row
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    public struct DynamicRow<T>
        where T : struct
    {
        /// <summary>
        /// The record fields
        /// </summary>
        public readonly ClrTableFields Fields;

        /// <summary>
        /// The cell values
        /// </summary>
        public readonly dynamic[] Cells;

        [MethodImpl(Inline)]
        public DynamicRow(ClrTableFields fields, dynamic[] cells)
        {
            Fields = fields;
            Cells = cells;
        }

        public void Update(in T src)
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<FieldCount; i++)
                this[i] = Fields[i].Definition.GetValueDirect(tr);
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public ref dynamic this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells,index);
        }

        public ref dynamic this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells,index);
        }

        [MethodImpl(Inline)]
        public static implicit operator DynamicRow(DynamicRow<T> src)
            => new DynamicRow(src.Fields, src.Cells);
    }
}