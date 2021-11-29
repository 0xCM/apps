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
        [Op, Closures(UInt8k)]
        public static AsciSequence asci<T>(W8 w, in Sym<T> symbol)
            where T : unmanaged
                => asci(w, n5, symbol.Expr, symbol.Kind);

        public static uint asci<T>(W8 w, N5 n, in SymExpr symbol, T kind, uint offset, Span<byte> dst)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            AsciSymbols.encode(desc, slice(dst,offset));
            return (uint)width;
        }

        public static AsciSequence asci<T>(W8 w, N5 n, in SymExpr symbol, T kind)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            var dst = alloc<byte>(width);
            AsciSymbols.encode(desc, dst);
            return AsciSymbols.seq(dst);
        }
    }
}