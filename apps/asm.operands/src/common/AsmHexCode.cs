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
            => asm.bitstring(this).Format();

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
            => asm.asmhex(src.View);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(ReadOnlySpan<byte> src)
            => asm.asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(byte[] src)
            => asm.asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(string src)
            => AsmParser.asmhex(src);

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