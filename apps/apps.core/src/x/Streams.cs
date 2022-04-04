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