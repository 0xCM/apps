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

    partial struct BitfieldSpecs
    {
        [MethodImpl(Inline), Op]
        public static BitfieldModel bitfield(Identifier name, Index<BitfieldSegModel> segs)
            => new BitfieldModel(name, segs, width(segs));

        public static BitfieldModel bitfield<K>(Identifier name, Symbols<K> symbols)
            where K : unmanaged
        {
            var count = symbols.Count;
            var segs = alloc<BitfieldSegModel>(count);
            var syms = symbols.View;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref skip(syms,i);
                var expr = sym.Expr.Format();
                var width = bw32(sym.Kind);
                seek(segs,i) = BitfieldSpecs.segment(expr, i, offset, width);
                offset += width;
            }
            return BitfieldSpecs.bitfield(name, segs);
        }
    }
}