//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public struct AsmHexCode : IEquatable<AsmHexCode>, IComparable<AsmHexCode>
    {
        [Op]
        public static bool asmhex(ReadOnlySpan<char> src, out AsmHexCode dst)
        {
            var storage = Cells.alloc(w128);
            var size = Hex.parse(src, storage.Bytes);
            if(size == 0 || size > 15)
            {
                dst = AsmHexCode.Empty;
                return false;
            }
            else
            {
                dst = new AsmHexCode(storage);
                dst.Cell(15) = (byte)size;
                return true;
            }
        }

        [Op]
        public static AsmHexCode asmhex(string src)
        {
            var dst = AsmHexCode.Empty;
            asmhex(src.Trim(), out dst);
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
        public static AsmHexCode asmhex(ReadOnlySpan<byte> src)
        {
            var cell = Cells.alloc(w128);
            var count = (byte)min(src.Length, 15);
            var dst = bytes(cell);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            BitNumbers.cell8(cell, 15) = count;
            return new AsmHexCode(cell);
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode asmhex(ulong src)
        {
            var size = bits.effsize(src);
            var data = slice(bytes(src), 0, size);
            var storage = 0ul;
            var buffer = bytes(storage);
            core.reverse(data, buffer);
            return new AsmHexCode(Cells.cell128(u64(first(buffer)), (ulong)size << 56));
        }

        public const byte SizeIndex = 15;

        Cell128 Data;

        [MethodImpl(Inline)]
        public AsmHexCode(Cell128 data)
            => Data = data;

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

        [MethodImpl(Inline)]
        public byte ToUInt8()
            => (byte)Data.Lo;

        [MethodImpl(Inline)]
        public ushort ToUInt16()
            => (ushort)Data.Lo;

        [MethodImpl(Inline)]
        public uint ToUInt32()
            => (uint)Data.Lo;

        [MethodImpl(Inline)]
        public uint ToUInt64()
            => (uint)Data.Lo;

        public string BitString
            => bitstring(this);

        public override int GetHashCode()
            => hash(this);

        [MethodImpl(Inline)]
        public bool Equals(AsmHexCode src)
            => eq(this, src);

        public override bool Equals(object src)
            => src is AsmHexCode x && Equals(x);

        public string Format()
            => Data.FormatHexData(Size);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(AsmHexCode src)
            => cmp(Bytes, src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(BinaryCode src)
            => asmhex(src.View);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(ReadOnlySpan<byte> src)
            => asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(byte[] src)
            => asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(string src)
            => asmhex(src);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmHexCode a, AsmHexCode b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmHexCode a, AsmHexCode b)
            => !a.Equals(b);

        public static AsmHexCode Empty
        {
            [MethodImpl(Inline)]
            get => default;
        }

        [MethodImpl(Inline), Op]
        public static Span<byte> encoded(in AsmHexCode src)
            => slice(bytes(src.Data), 0, src.Size);

        [Op]
        public static uint render(in AsmHexCode src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.Size;
            var bytes = src.Bytes;
            for(var j=0; j<count; j++)
            {
                ref readonly var b = ref skip(bytes, j);
                Hex.render(LowerCase, (Hex8)b, ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(in AsmHexCode a, in AsmHexCode b)
            => a.Data.Equals(b.Data);

        [MethodImpl(Inline), Op]
        public static int hash(in AsmHexCode src)
            => (int)alg.ghash.calc(encoded(src));
    }
}