//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;

    [Free, ApiHost]
    public partial class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        public static void emit(SymHeap src, FS.FilePath dst, IWfEventTarget log)
            => Tables.emit(log, Heaps.entries(src).View, dst, TextEncodingKind.Unicode);

        [Op]
        static Outcome<uint> parse(ReadOnlySpan<AsciCode> src, ref uint i, Span<byte> dst)
        {
            var i0 = i;
            var counter = 0u;
            var count = src.Length;
            ref var target = ref first(dst);
            var hi = byte.MaxValue;
            var lo = byte.MaxValue;
            for(var j=0; j<count; j++,i++)
            {
                ref readonly var c = ref skip(src,j);
                if(SQ.whitespace(c) || Hex.specifier(c))
                    continue;

                if(Hex.parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        lo = (byte)d;
                        seek(target, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                        lo = byte.MaxValue;
                    }
                }
                else
                    return false;
            }
            return (true, counter);
        }

        public static MemoryHeap load(FS.FilePath src)
        {
            var dst = sys.alloc<byte>(src.Size);
            using var reader = src.AsciLineReader();
            var line = AsciLineCover.Empty;
            var offset = 0u;
            var result = true;
            while(reader.Next(out line) && result)
            {
                var data = line.Codes;
                var i = SQ.index(data, Chars.Space);
                if(i > 0)
                {
                    result = Hex.parse(SQ.left(data,i), out ulong a);
                    result &= parse(SQ.right(data,i), ref offset, dst);
                }

            }
            return default;
        }

        [MethodImpl(Inline), Op]
        public static MemoryHeap memory(MemoryAddress @base, Span<byte> data, Span<Address32> offsets)
            => new MemoryHeap(@base, data,offsets);

        public static asci16 id(SymHeap src)
            => string.Format("H{0:X4}x{1:X4}x{2:X6}", src.SymbolCount, src.EntryCount, src.ExprLengths.Storage.Sum());

        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => core.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        [MethodImpl(Inline)]
        public static ref HeapEntry<K,O,L> convert<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return ref dst;
        }
   }
}