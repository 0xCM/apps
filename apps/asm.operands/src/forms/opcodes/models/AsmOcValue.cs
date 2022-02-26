//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmOcValue : IEquatable<AsmOcValue>, IComparable<AsmOcValue>
    {
        readonly ByteBlock4 Data;

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0)
        {
            Data = b0;
        }

        [MethodImpl(Inline)]
        public AsmOcValue(ReadOnlySpan<byte> src)
        {
            switch(src.Length)
            {
                case 0:
                    Data = 0u;
                break;
                case 1:
                    Data = skip(src,0);
                break;
                case 2:
                    Data = @as<ushort>(src);
                break;
                case 3:
                    Data = (uint)@as<ushort>(src) | ((uint)skip(src,2) << 16);
                break;
                default:
                    Data = @as<uint>(src);
                break;
            }
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1)
        {
            Data = Bytes.join(w32,b0,b1);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1, byte b2)
        {
            Data = Bytes.join(w32,b0,b1,b2);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1, byte b2, byte b3)
        {
            Data = Bytes.join(w32,b0,b1,b2,b3);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(uint src)
        {
            Data = src;
        }

        public ReadOnlySpan<byte> ToSpan()
            => slice(Data.Bytes,0, StorageBlocks.trim(Data).TrimmedSize);

        public string Format()
            => StorageBlocks.trim(Data).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmOcValue src)
            => Data == src.Data;

        public override bool Equals(object src)
            => src is AsmOcValue x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(AsmOcValue src)
            => ((uint)Data).CompareTo((uint)src.Data);

        public override int GetHashCode()
            => (int)((uint)Data);

        [MethodImpl(Inline)]
        public static implicit operator Hex32(AsmOcValue src)
            => (uint)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(Hex32 src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(uint src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(ReadOnlySpan<byte> src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(ByteBlock4 src)
            => new AsmOcValue(src);

    }
}