//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.Text;

    using static Root;
    using static core;

    partial class XTend
    {
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
    }
}