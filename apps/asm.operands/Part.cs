//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading.Tasks;
global using static Z0.Root;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;

[assembly: PartId(PartId.AsmOperands)]
namespace Z0.Parts
{
    public sealed class AsmOperands : Part<AsmOperands>
    {
    }
}

namespace Z0
{
    using System.IO;

    using static core;

    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static bool Test<E>(this E src, E flag)
            where E : unmanaged, Enum
        {
            var x = core.bw64(src);
            var y = core.bw64(flag);
            return (x & y) != 0;
        }

        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this ReadOnlySpan<T> src, Func<T, bool> f)
            => ArrayUtil.where(src, f);

        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this T[] src, Func<T, bool> f)
            => ArrayUtil.where(src, f);

        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this Span<T> src, Func<T, bool> f)
            => ArrayUtil.where(src, f);

        public static uint AddRange<T>(this HashSet<T> dst, ReadOnlySpan<T> src)
        {
            var counter = 0u;
            foreach(var item in src)
                if(dst.Add(item))
                    counter++;
            return counter;
        }

        public static uint AddRange<T>(this HashSet<T> dst, params T[] src)
            => dst.AddRange(@readonly(src));

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

        [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this T[] src)
            => src;

        [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this IEnumerable<T> src)
            => src.Array();

    }

    partial struct Msg
    {

    }

    public static class XSvc
    {
        public static AppDb AppDb(this IWfRuntime wf)
            => Z0.AppDb.create(wf);
    }
}