/*
        [Op]
        public static SymHeap create(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();
            var count = (uint)src.Length;
            var kEntry = (uint)bits.next((Pow2x32)bits.xmsb(count));
            dst.SymbolCount = count;
            dst.EntryCount = kEntry;
            dst.ExprLengths = alloc<uint>(kEntry);
            dst.Values = alloc<SymVal>(kEntry);
            dst.Names = alloc<Identifier>(kEntry);
            dst.ExprData = alloc<char>(charcount(src));
            dst.ExprOffsets = alloc<uint>(kEntry);
            dst.Sources = alloc<Identifier>(kEntry);
            ref var exprwidths = ref dst.ExprLengths.First;
            ref var values = ref dst.Values.First;
            ref var symdst = ref dst.ExprData.First;
            ref var offsets = ref dst.ExprOffsets.First;

            ref var id = ref dst.Names.First;
            ref var sources = ref dst.Sources.First;
            var exprOffset=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                var symsrc = row.Symbol.Data;
                var namesrc = span(row.Name.Text);
                var width = (ushort)symsrc.Length;
                seek(exprwidths, i) = (ushort)symsrc.Length;
                seek(values, i) = row.Value;
                seek(id, i) = row.Name;
                seek(offsets,i) = exprOffset;
                seek(sources,i) = row.Type;
                symsrc.CopyTo(cover(seek(symdst, exprOffset), (ushort)symsrc.Length));

                exprOffset += width;
            }

            return dst;
        }

*/