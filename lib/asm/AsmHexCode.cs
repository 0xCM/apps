//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public struct AsmHexCode : IDataTypeComparable<AsmHexCode>
    {
        public const byte SizeIndex = 15;

        Cell128 Data;

        [MethodImpl(Inline)]
        public AsmHexCode(Cell128 data)
            => Data = data;

        public byte Size
        {
            [MethodImpl(Inline)]
            get => size(this);
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

        public override int GetHashCode()
            => hash(this);

        [MethodImpl(Inline)]
        public bool Equals(AsmHexCode src)
            => eq(this, src);

        public override bool Equals(object src)
            => src is AsmHexCode x && Equals(x);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(AsmHexCode src)
            => compare(this, src);

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

        [Op]
        public static string format(in AsmHexCode src)
            => src.Data.FormatHexData(src.Size);

        [MethodImpl(Inline), Op]
        public static int compare(in AsmHexCode a, in AsmHexCode b)
        {
            var left = recover<ulong>(raw(a));
            var right = recover<ulong>(raw(b));
            var x = first(left).CompareTo(first(right));
            if(x != 0)
                return x;
            else
                return skip(left,1).CompareTo(skip(right,1));
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode load(ReadOnlySpan<byte> src)
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
        public static AsmHexCode load(ulong src)
        {
            var size = bits.effsize(src);
            var data = slice(bytes(src), 0, size);
            var storage = 0ul;
            var buffer = bytes(storage);
            core.reverse(data, buffer);
            return new AsmHexCode(Cells.cell128(u64(first(buffer)), (ulong)size << 56));
        }

        [MethodImpl(Inline), Op]
        public static byte size(in AsmHexCode src)
            => BitNumbers.cell8(src.Data, AsmHexCode.SizeIndex);

        [MethodImpl(Inline), Op]
        public static Span<byte> encoded(in AsmHexCode src)
            => slice(bytes(src.Data), 0, src.Size);

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AsmHexCode dst)
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
            => (int)alg.hash.calc(encoded(src));

        [Op]
        public static AsmHexCode parse(string src)
        {
            var dst = AsmHexCode.Empty;
            parse(src.Trim(), out dst);
            return dst;
        }

        [Op]
        public static string bitstring(in AsmHexCode src)
        {
            if(src.IsEmpty)
                return default;

            CharBlocks.alloc(n256, out var block);
            var dst = block.Data;
            var count = AsmBitstring.render(src, dst);
            if(count == 0)
                return EmptyString;

            return text.format(slice(dst, 0, count));
        }

        [MethodImpl(Inline), Op]
        static Span<byte> raw(in AsmHexCode src)
            => bytes(src.Data);
    }
}