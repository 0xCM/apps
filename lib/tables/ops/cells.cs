//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static uint cells<T>(in RowFormatSpec rowspec, in DynamicRow<T> row, Span<string> dst)
            where T : struct
        {
            var values = @readonly(row.Cells);
            var specs = rowspec.Cells.View;
            var count = (uint)min(specs.Length,values.Length);
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref skip(values,i);
                ref readonly var spec = ref skip(specs,i);
                var cellpad = spec.Width.Pattern();
                seek(dst, i) = string.Format(cellpad, spec.Pattern.Format(value));
            }

            return count;
        }

        public static Outcome cells(TextLine src, char delimiter, byte fields, out ReadOnlySpan<string> dst)
        {
            var cells = src.Split(Chars.Pipe, true);
            dst = default;
            if(cells.Length != fields)
            {
                return (false, Tables.FieldCountMismatch.Format(fields, cells.Length));
            }
            else
            {
                dst = cells;
                return true;
            }
        }
    }
}