//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static string pairs<T>(in RowFormatSpec spec, in RowAdapter<T> src)
            where T : struct
        {
            var dst = text.buffer();
            pairs(spec, src, dst);
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static void pairs<T>(in RowFormatSpec spec, in RowAdapter<T> src, ITextBuffer dst)
            where T : struct
        {
            var pattern = KvpPattern(spec);
            var cells = src.Cells;
            var count = cells.Length;
            var fields = src.Fields.View;
            for(var i=0; i<count; i++)
                dst.AppendLineFormat(pattern, skip(fields,i).MemberName, skip(cells,i));
            dst.AppendLine();
        }
    }
}