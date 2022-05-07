//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        /// <summary>
        /// Defines a <see cref='RowFormatSpec'/>
        /// </summary>
        /// <param name="header">The row header</param>
        /// <param name="cells">The cell specs</param>
        [MethodImpl(Inline), Op]
        public static RowFormatSpec rowspec(RowHeader header, CellFormatSpec[] cells, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            => new RowFormatSpec(header, cells, pattern(cells, header.Delimiter), rowpad, Chars.Pipe, fk);

        /// <summary>
        /// Defines a <see cref='RowFormatSpec'/>
        /// </summary>
        /// <param name="widths">The cell widths</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var _header = header<T>(widths);
            return rowspec(_header, _header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }

        /// <summary>
        /// Defines a <see cref='RowFormatSpec'/>
        /// </summary>
        /// <param name="fieldwidth">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(byte fieldwidth = DefaultFieldWidth, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var _header = header<T>(fieldwidth);
            return rowspec(_header, _header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }
    }
}