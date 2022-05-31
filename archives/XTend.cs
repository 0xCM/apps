//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System.IO;

    using static core;

    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;

        [Op]
        public static AsciLineReader AsciLineReader(this FS.FilePath src)
            => new AsciLineReader(src.AsciReader());

        [Op]
        public static UnicodeLineReader UnicodeLineReader(this FS.FilePath src)
            => new UnicodeLineReader(src.UnicodeReader());

        public static void AppendLines<T>(this ITextEmitter dst, ReadOnlySpan<T> src)
        {
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i));
        }

        public static void AppendLines<T>(this ITextEmitter dst, Span<T> src)
        {
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i));
        }

        public static void Pipe<T>(this IWfDb Db, ReadOnlySpan<T> src, string channel = null)
            where T : ITextual
        {
            var count = src.Length;
            if(count != 0)
            {
                var dst = Db.AppLog(string.Format("{0}.{1}", Timestamp.now(), channel ?? typeof(T).Name));
                using var writer = dst.AsciWriter();
                for(var i=0; i<count; i++)
                    writer.WriteLine(skip(src,i).Format());
            }
        }

        public static void Pipe<S,T>(this IWfDb Db, ReadOnlySpan<S> src, Func<S,T> converter, string channel = null)
            where T : ITextual
        {
            var count = src.Length;
            if(count != 0)
            {
                var dst = Db.AppLog(string.Format("{0}.{1}",Timestamp.now(), channel ?? typeof(T).Name));
                using var writer = dst.AsciWriter();
                for(var i=0; i<count; i++)
                    writer.WriteLine((converter(skip(src,i)).Format()));
            }
        }


        public static void Pipe<S,T>(this IAppService svc, ReadOnlySpan<S> src, Func<S,T> converter, string channel = null)
            where T : ITextual
                => svc.Db.Pipe(src,converter,channel);

        public static void Pipe<T>(this IAppService svc, ReadOnlySpan<T> src, string channel = null)
            where T : ITextual
                => svc.Db.Pipe(src, channel);

        public static void Indent<T>(this StreamWriter dst,  uint margin, T src)
            => dst.Append(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public static void IndentFormat<T>(this StreamWriter dst, uint margin, string format, T src)
            => dst.Indent(margin, string.Format(format,src));

        public static void IndentLine<T>(this StreamWriter dst, uint margin, T src)
            => dst.AppendLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public static void IndentLineFormat(this StreamWriter dst, uint margin, string pattern, params object[] args)
            => dst.IndentLine(margin, string.Format(pattern, args));

        public static void Emit(this ITextBuffer src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            using var writer = dst.Writer(encoding);
            writer.Write(src.Emit());
        }
    }
}