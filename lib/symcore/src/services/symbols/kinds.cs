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

    partial struct Symbols
    {

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint kinds<T>(Symbols<T> src, Span<T> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length,dst.Length);
            var view = src.Kinds;
            for(var i=0u; i<count; i++)
                seek(dst,i) = skip(view,i);
            return count;
        }

        [Op, Closures(Closure)]
        public static uint kinds<K>(in Symbols<K> src, Span<SymKindRow> dst)
            where K : unmanaged
        {
            var symbols = src.View;
            var count = (uint)min(symbols.Length, dst.Length);
            var type = typeof(K).Name;
            for(var i=0; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var symbol = ref skip(symbols,i);
                target.Index = symbol.Key;
                target.Name = symbol.Name;
                target.Value = bw64(symbol.Kind);
                target.Type = type;
            }
            return count;
        }
    }
}