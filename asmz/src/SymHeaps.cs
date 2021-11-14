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

    [ApiHost]
    public readonly struct SymHeaps
    {
        [MethodImpl(Inline), Op]
        public static ushort width(SymHeapSpec src, ushort index)
            => width(src.Widths, index);

        [MethodImpl(Inline), Op]
        public static ushort width(ReadOnlySpan<ushort> src, ushort index)
            => skip(src,index);

        [MethodImpl(Inline), Op]
        public static uint offset(SymHeapSpec src, ushort index)
            => offset(src.Offsets, index);

        [MethodImpl(Inline), Op]
        public static uint offset(ReadOnlySpan<uint> src, ushort index)
            => skip(src, index);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> symchars(SymHeapSpec src, ushort index)
            => slice(src.Expressions.View, offset(src.Offsets.View, index), width(src,index));

        [Op]
        public static SymExpr symexpr(SymHeapSpec src, ushort index)
            => text.format(symchars(src,index));

        [MethodImpl(Inline), Op]
        public static ref readonly Identifier identifier(SymHeapSpec src, ushort index)
            => ref src.Identifiers[index];

        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var width = 0u;
            var kSrc = src.Length;
            for(var i=0; i<kSrc; i++)
            {
                ref readonly var symbol = ref skip(src,i).Symbol;
                width += (uint)symbol.CharCount;
            }
            return width;
        }

        [Op]
        public static SymHeapSpec specify(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapSpec();

            var kSym = (uint)src.Length;
            var kEntry = (uint)bits.next((Pow2x16)bits.xmsb(kSym));
            dst.SymbolCount = kSym;
            dst.EntryCount = kEntry;
            dst.Widths = alloc<ushort>(kEntry);
            dst.Values = alloc<ushort>(kEntry);
            dst.Identifiers = alloc<Identifier>(kEntry);
            dst.Expressions = alloc<char>(charcount(src));
            dst.Offsets = alloc<uint>(kEntry);

            ref var widths = ref dst.Widths.First;
            ref var values = ref dst.Values.First;
            ref var symdst = ref dst.Expressions.First;
            ref var offsets = ref dst.Offsets.First;
            ref var id = ref dst.Identifiers.First;
            var offset=0u;
            for(var i=0; i<kSym; i++)
            {
                ref readonly var literal = ref skip(src,i);
                var symsrc = literal.Symbol.Data;
                var width = (ushort)symsrc.Length;
                seek(widths, i) = width;
                seek(values, i) = (ushort)literal.ScalarValue;
                seek(id, i) = literal.Name;
                seek(offsets,i) = offset;
                symsrc.CopyTo(cover(seek(symdst, offset), width));

                offset += width;
            }

            return dst;
        }
    }
}