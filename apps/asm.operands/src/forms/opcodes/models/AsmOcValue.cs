//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmOcValue : IEquatable<AsmOcValue>, IComparable<AsmOcValue>
    {
        readonly ByteBlock4 Storage;

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0)
        {
            Storage = b0;
        }

        [MethodImpl(Inline)]
        public AsmOcValue(ReadOnlySpan<byte> src)
        {
            switch(src.Length)
            {
                case 0:
                    Storage = 0u;
                break;
                case 1:
                    Storage = skip(src,0);
                break;
                case 2:
                    Storage = @as<ushort>(src);
                break;
                case 3:
                    Storage = (uint)@as<ushort>(src) | ((uint)skip(src,2) << 16);
                break;
                default:
                    Storage = @as<uint>(src);
                break;
            }
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1)
        {
            Storage = Bytes.join(w32,b0,b1);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1, byte b2)
        {
            Storage = Bytes.join(w32,b0,b1,b2);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1, byte b2, byte b3)
        {
            Storage = Bytes.join(w32,b0,b1,b2,b3);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(uint src)
        {
            Storage = src;
        }

        public ReadOnlySpan<byte> ToSpan()
            => slice(Storage.Bytes, 0, StorageBlocks.trim(Storage).TrimmedSize);

        public byte TrimmedSize
        {
            [MethodImpl(Inline)]
            get => (byte)StorageBlocks.trim(Storage).TrimmedSize;
        }

        public ReadOnlySpan<byte> Trimmed
        {
            [MethodImpl(Inline)]
            get => slice(Storage.Bytes, 0, TrimmedSize);
        }

        public string Format()
            => StorageBlocks.trim(Storage).Format();

        public string Format(bool prespec, bool uppercase)
            => StorageBlocks.trim(Storage).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmOcValue src)
            => Storage == src.Storage;

        public override bool Equals(object src)
            => src is AsmOcValue x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(AsmOcValue src)
            => ((uint)Storage).CompareTo((uint)src.Storage);

        public override int GetHashCode()
            => (int)((uint)Storage);

        [MethodImpl(Inline)]
        public static implicit operator Hex32(AsmOcValue src)
            => (uint)src.Storage;

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