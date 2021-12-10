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
        /// <summary>
        /// Extracts the symbol expressions from a source buffer and deposits them in a caller-supplied target
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint expressions<T>(Symbols<T> src, Span<SymExpr> dst)
            where T : unmanaged
        {
            var count = src.Length;
            var view = src.View;
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(view,i).Expr;
            return (uint)count;
        }

        [MethodImpl(Inline),Op, Closures(Closure)]
        public static uint expr<T>(Symbols<T> src, Span<text7> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, dst.Length);
            var symbols = src.View;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                var data = symbol.Expr.Data;
                seek(dst, i) = FixedChars.txt(n7, data);
            }
            return count;
        }
    }
}