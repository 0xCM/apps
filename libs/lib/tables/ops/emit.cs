//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static Spans;

    partial struct Tables
    {
        public static void emit<T>(IWfEventTarget log, ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = Events.emittingTable<T>(log.Host, dst);
            log.Deposit(emitting);
            var formatter = RecordFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
             var emitted = Events.emittedTable<T>(log.Host, rows.Length, dst);
             log.Deposit(emitted);
        }

        public static void emit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var formatter = RecordFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, StreamWriter dst)
            where T : struct
                => emit(src,Tables.rowspec<T>(DefaultFieldWidth), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, StreamWriter dst)
            where T : struct
        {
            var formatter = Tables.formatter<T>(spec);
            var count = src.Length;
            dst.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            dst.WriteLine(formatter.Format(skip(src,i)));
            return count;
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, Encoding encoding, FS.FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, spec, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => emit(src, spec, encoding.ToSystemEncoding(), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, FS.FilePath dst)
            where T : struct
                => emit(src, spec, TextEncodingKind.Utf8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, Encoding encoding, FS.FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
                => emit(src, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
                => emit(src, widths, z16, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FS.FilePath dst)
            where T : struct
                => emit(src, rowspec<T>(widths, rowpad), dst);

        public static Count emit<T>(ReadOnlySpan<T> src, ITextEmitter dst)
            where T : struct
        {
            var count = src.Length;
            var f = formatter<T>();
            dst.AppendLine(f.FormatHeader());
            for(var i=0; i<count; i++)
                dst.AppendLine(f.Format(skip(src,i)));
            return count;
        }
    }
}