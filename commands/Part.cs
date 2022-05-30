//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Diagnostics;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading;
global using System.Threading.Tasks;
global using System.IO;

global using static Z0.Root;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

[assembly: PartId(PartId.Commands)]

namespace Z0.Parts
{
    public sealed partial class Commands : Part<Commands>
    {

    }
}

namespace Z0
{
    using static core;

    public static partial class XTend
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

        [MethodImpl(Inline)]
        public static bool Test<E>(this E src, E flag)
            where E : unmanaged, Enum
                => (core.bw64(src) & core.bw64(flag)) != 0;
        public static void AddRange<T>(this HashSet<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }

        public static void AddRange<T>(this ConcurrentBag<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }

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

        public static string Format<C>(this C src)
            where C : struct, ICmd<C>
                => Cmd.format(src);
    }
}
