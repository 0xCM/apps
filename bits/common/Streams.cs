//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    partial class XTend
    {
        public static string Delimit<T>(this ReadOnlySpan<T> src, string sep, short pad = 0)
        {
            var dst = text.buffer();
            var slot = RP.slot(0,pad);

            for(var i=0; i<src.Length; i++)
            {
                if(i != 0)
                    dst.Append(sep);

                dst.AppendFormat(slot, skip(src,i));
            }
            return dst.Emit();
        }

        public static string Delimit<T>(this Span<T> src, string sep, short pad = 0)
            => (@readonly(src)).Delimit(sep,pad);

        public static string Delimit<T>(this T[] src, string sep, short pad = 0)
            => (@readonly(src)).Delimit(sep,pad);

        public static string Delimit<T>(this Index<T> src, string sep, short pad = 0)
            => (src.View).Delimit(sep,pad);

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

        public static void Pipe<S,T>(this IAppService svc, ReadOnlySpan<S> src, Func<S,T> converter, string channel = null)
            where T : ITextual
                => svc.Db.Pipe(src,converter,channel);

        public static void Pipe<T>(this IAppService svc, ReadOnlySpan<T> src, string channel = null)
            where T : ITextual
                => svc.Db.Pipe(src, channel);

        [MethodImpl(Inline)]
        public static void AppendLineFormat(this StreamWriter dst, string pattern, params object[] args)
            => dst.WriteLine(string.Format(pattern,args));

        [MethodImpl(Inline)]
        public static void AppendFormat(this StreamWriter dst, string pattern, params object[] args)
            => dst.Write(string.Format(pattern,args));

        [MethodImpl(Inline)]
        public static void AppendLine(this StreamWriter dst)
            => dst.WriteLine();

        [MethodImpl(Inline)]
        public static void AppendLine(this StreamWriter dst, object src)
            => dst.WriteLine(src);

        [MethodImpl(Inline)]
        public static void Append(this StreamWriter dst, object src)
        {
            if(src != null)
                dst.Write(src);
        }

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