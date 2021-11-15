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
        [MethodImpl(Inline)]
        public static SymGrid<R,C> grid<R,C>(Symbols<R> rows, Symbols<C> cols)
            where R : unmanaged
            where C : unmanaged
                => new SymGrid<R,C>(rows, cols);

        [Op,Closures(UInt8k)]
        public static AsciGrid<T> grid<T>(Symbols<T> src, ushort width)
            where T : unmanaged
        {
            var symbols = src.View;
            var count = symbols.Length;
            var size = count*width;
            var dst = alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                offset += asci(w8, n5, symbol.Expr, symbol.Kind, offset, dst);
            }
            return new AsciGrid<T>(AsciSymbols.seq(dst), width);
        }
    }
}