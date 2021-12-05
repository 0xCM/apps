//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static string pairs<T>(in RowAdapter<T> src)
            where T : struct
        {
            const char RowSep = Chars.Comma;
            const char ValSep = Chars.Eq;
            const string KVRP = "{0,-48}: {1}" + Eol;

            var dst = text.buffer();
            var cells = src.Cells;
            var count = cells.Length;
            var fields = src.Fields.View;
            for(var i=0; i<count; i++)
                dst.AppendFormat(KVRP, skip(fields,i).Name, skip(cells,i));
            return dst.Emit();
        }
    }
}