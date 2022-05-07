//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct SymHeaps
    {
        [MethodImpl(Inline), Op]
        public static ref readonly uint width(SymHeap src, uint index)
            => ref width(src.Widths, index);

        [MethodImpl(Inline), Op]
        public static ref readonly uint width(ReadOnlySpan<uint> src, uint index)
            => ref skip(src,index);

        [MethodImpl(Inline), Op]
        public static ref readonly uint offset(SymHeap src, uint index)
            => ref offset(src.Offsets, index);

        [MethodImpl(Inline), Op]
        public static ref readonly uint offset(ReadOnlySpan<uint> src, uint index)
            => ref skip(src, index);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> symchars(SymHeap src, uint index)
            => slice(src.Expressions.View, offset(src.Offsets.View, index), width(src,index));

        [Op]
        public static SymExpr symexpr(SymHeap src, uint index)
            => text.format(symchars(src,index));

        [MethodImpl(Inline), Op]
        public static ref readonly Identifier name(SymHeap src, uint index)
            => ref src.Names[index];

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
        public static Index<SymHeapEntry> entries(SymHeap src)
        {
            var count = src.SymbolCount;
            var entries = alloc<SymHeapEntry>(count);
            for(var i=0u; i<count; i++)
            {
                ref var entry = ref seek(entries,i);
                entry.Index = i;
                entry.Offset = src.Offset(i);
                entry.Source = src.Source(i);
                entry.Name = src.Name(i);
                entry.Value = src.Value(i);
                entry.Expression = src.Expression(i);
            }
            return entries;
        }

        [Op]
        public static SymHeap define(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();

            var kSym = (uint)src.Length;
            var kEntry = (uint)bits.next((Pow2x32)bits.xmsb(kSym));
            dst.SymbolCount = kSym;
            dst.EntryCount = kEntry;
            dst.Widths = alloc<uint>(kEntry);
            dst.Values = alloc<SymVal>(kEntry);
            dst.Names = alloc<Identifier>(kEntry);
            dst.Expressions = alloc<char>(charcount(src));
            dst.Offsets = alloc<uint>(kEntry);
            dst.Sources = alloc<Identifier>(kEntry);

            ref var widths = ref dst.Widths.First;
            ref var values = ref dst.Values.First;
            ref var symdst = ref dst.Expressions.First;
            ref var offsets = ref dst.Offsets.First;
            ref var id = ref dst.Names.First;
            ref var sources = ref dst.Sources.First;
            var offset=0u;
            for(var i=0; i<kSym; i++)
            {
                ref readonly var literal = ref skip(src,i);
                var symsrc = literal.Symbol.Data;
                var width = (ushort)symsrc.Length;
                seek(widths, i) = width;
                seek(values, i) = literal.Value;
                seek(id, i) = literal.Name;
                seek(offsets,i) = offset;
                seek(sources,i) = literal.Type;
                symsrc.CopyTo(cover(seek(symdst, offset), width));

                offset += width;
            }

            return dst;
        }
    }
}