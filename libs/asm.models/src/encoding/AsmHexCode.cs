//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public record struct AsmHexCode : IEquatable<AsmHexCode>, IComparable<AsmHexCode>
    {
        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AsmHexCode dst)
        {
            var buffer = Cells.alloc(w128);
            var result = Hex.parse(src, buffer.Bytes);
            dst = AsmHexCode.Empty;
            if(result.Fail)
                return result;

            var size = result.Data;
            if(size == 0 || size > 15)
                result = false;
            else
            {
                dst = new AsmHexCode(buffer);
                dst.Cell(15) = (byte)size;
                result = true;
            }
            return result;
        }

        [Op]
        public static AsmHexCode parse(string src)
        {
            var dst = AsmHexCode.Empty;
            parse(src.Trim(), out dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint bitstring(in AsmHexCode src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(slice(src.Bytes, 0, src.Size), ref i, dst);
        }

        [Op]
        public static string bitstring(in AsmHexCode src)
        {
            if(src.IsEmpty)
                return default;

            CharBlocks.alloc(n256, out var block);
            var dst = block.Data;
            var count = bitstring(src, dst);
            if(count == 0)
                return EmptyString;

            return text.format(slice(dst, 0, count));
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode load(ReadOnlySpan<byte> src)
        {
            var cell = Cells.alloc(w128);
            var count = (byte)min(src.Length, 15);
            var dst = core.bytes(cell);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            BitNumbers.cell8(cell, 15) = count;
            return new AsmHexCode(cell);
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode load(ulong src)
        {
            var size = bits.effsize(src);
            var data = slice(core.bytes(src), 0, size);
            var storage = 0ul;
            var buffer = core.bytes(storage);
            core.reverse(data, buffer);
            return new AsmHexCode(Cells.cell128(u64(first(buffer)), (ulong)size << 56));
        }

        [MethodImpl(Inline), Op]
        public static Span<byte> encoded(AsmHexCode src)
            => slice(core.bytes(src.Data), 0, src.Size);

        [MethodImpl(Inline), Op]
        public static bool eq(AsmHexCode a, AsmHexCode b)
            => a.Data.Equals(b.Data);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(AsmHexCode src)
            => core.hash(encoded(src));

        [Op]
        public static uint render(AsmHexCode src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.Size;
            var bytes = src.Bytes;
            for(var j=0; j<count; j++)
            {
                Hex.render(LowerCase, (Hex8)skip(bytes, j), ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i - i0;
        }

        const byte SizeIndex = 15;

        Cell128 Data;

        [MethodImpl(Inline)]
        public AsmHexCode(Cell128 data)
        {
            Data = data;
        }

        public ref byte Size
        {
            [MethodImpl(Inline)]
            get => ref seek(Data.Bytes,SizeIndex);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => encoded(this);
        }

        [MethodImpl(Inline)]
        public ref byte Cell(byte index)
            => ref seek(Bytes,index);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public ref byte this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes,index);
        }

        public ref byte this[sbyte index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes, index < 0 ? 0 : (byte)index);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(this);
        }

        public string BitString
            => bitstring(this);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmHexCode src)
            => eq(this, src);

        public string Format()
            => Data.FormatHexData(Size);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(AsmHexCode src)
            => core.cmp(Bytes, src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(BinaryCode src)
            => load(src.View);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(ReadOnlySpan<byte> src)
            => load(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(byte[] src)
            => load(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(string src)
            => parse(src);

        public static AsmHexCode Empty
        {
            [MethodImpl(Inline)]
            get => default;
        }
    }
}