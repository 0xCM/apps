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
        public static ReadOnlySpan<T> load<T>(FS.FilePath src, IRecordParser<T> parser)
            where T : struct
        {
            var dst = list<T>();
            using var reader = src.Utf8LineReader();
            if(reader.Next(out var header))
            {
                while(reader.Next(out var line))
                {
                    var result = parser.ParseRow(line, out var row);
                    if(result)
                        dst.Add(row);
                    else
                        break;
                }
            }
            return dst.ViewDeposited();
        }

        [Op, Closures(Closure)]
        public static void load<T>(in RecordField[] fields, uint index, in T src, ref DynamicRow<T> dst)
            where T : struct
        {
            dst = dst.UpdateSource(index, src);
            var tr = __makeref(edit(src));
            var count = fields.Length;
            var fv = @readonly(fields);
            var target = dst.Edit;
            for(var i=0u; i<count; i++)
                seek(target, i) = skip(fv, i).Definition.GetValueDirect(tr);
        }
    }
}