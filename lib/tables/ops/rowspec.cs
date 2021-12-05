//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Tables
    {
        /// <summary>
        /// Defines a <see cref='RowFormatSpec'/>
        /// </summary>
        /// <param name="header">The row header</param>
        /// <param name="cells">The cell specs</param>
        [MethodImpl(Inline), Op]
        public static RowFormatSpec rowspec(RowHeader header, CellFormatSpec[] cells, ushort rowpad = 0)
            => new RowFormatSpec(header, cells, pattern(cells, header.Delimiter), rowpad);

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec(Type record, ReadOnlySpan<byte> widths, ushort rowpad = 0)
        {
            var _header = header(record, widths);
            return rowspec(_header, _header.Cells.Select(x => x.CellFormat), rowpad);
        }

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec(Type record, byte width = DefaultFieldWidth, ushort rowpad = 0)
        {
            var _header = header(record, width);
            return rowspec(_header, _header.Cells.Select(x => x.CellFormat), rowpad);
        }

        /// <summary>
        /// Defines a <see cref='RowFormatSpec'/>
        /// </summary>
        /// <param name="widths">The cell widths</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0)
            where T : struct
        {
            var _header = header<T>(widths);
            return rowspec(_header, _header.Cells.Select(x => x.CellFormat), rowpad);
        }

        /// <summary>
        /// Defines a <see cref='RowFormatSpec'/>
        /// </summary>
        /// <param name="fieldwidth">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(byte fieldwidth = DefaultFieldWidth, ushort rowpad = 0)
            where T : struct
        {
            var _header = header<T>(fieldwidth);
            return rowspec(_header, _header.Cells.Select(x => x.CellFormat), rowpad);
        }
    }
}