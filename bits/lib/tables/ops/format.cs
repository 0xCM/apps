//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static string format<T>(ref RecordFormatter<T> formatter, in T src)
            where T : struct
        {
            adapt(src, ref formatter.Adapter);
            return format(formatter.FormatSpec, formatter.Adapter.Adapted);
        }

        [Op, Closures(Closure)]
        public static string format<T>(in T src)
            where T : struct
                => formatter<T>().Format(src);

        [Op, Closures(Closure)]
        public static string format<T>(ref RecordFormatter<T> formatter, in T src, RecordFormatKind kind)
            where T : struct
        {
            adapt(src, ref formatter.Adapter);
            if(kind == RecordFormatKind.Tablular)
                return format(formatter.FormatSpec, formatter.Adapter.Adapted);
            else
                return pairs(formatter.Adapter);
        }

        [Op, Closures(Closure)]
        public static string format<T>(in RowFormatSpec rowspec, in DynamicRow<T> src)
            where T : struct
        {
            var content = string.Format(rowspec.Pattern, src.Cells);
            var pad = rowspec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }

        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.buffer();
            format(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void format(ListedFiles src, ITextBuffer dst)
        {
            var records = src.View;
            var count = records.Length;
            var formatter = Tables.formatter<ListedFile>();
            dst.AppendLine(formatter.FormatHeader());
            for(var i=0u; i<count; i++)
            {
                ref readonly var listed = ref src[i];
                dst.AppendLine(formatter.Format(listed));
            }
        }

        [Op]
        public static void format(ListedFiles src, Span<string> dst)
        {
            var count = src.Count;
            var listed = src.View;
            var formatter = Tables.formatter<ListedFile>();
            ref readonly var file = ref src[0];
            ref var formatted = ref first(dst);

            for(var i=0u; i<count; i++)
                seek(formatted,i) = formatter.Format(skip(file,i));
        }

        /// <summary>
        /// Formats a <see cref='RowHeader'/>
        /// </summary>
        /// <param name="src">The source header</param>
        public static string format(RowHeader src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(src.Delimiter);

                dst.Append(src[i].Format());
            }
            return dst.ToString();
        }
   }
}