//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmOcValue : IEquatable<AsmOcValue>, IComparable<AsmOcValue>
    {
        public static string format(AsmOcValue src)
        {
            var data = src.Trimmed;
            var dst = "0x00";
            switch(data.Length)
            {
                case 1:
                    dst = string.Format("0x{0:X2}", skip(data,0));
                break;
                case 2:
                    dst = string.Format("0x{0:X2} 0x{1:X2}", skip(data,0), skip(data,1));
                break;
                case 3:
                    dst = string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2}", skip(data,0), skip(data,1), skip(data,2));
                break;
                case 4:
                    dst = string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} 0x{3:X2}", skip(data,0), skip(data,1), skip(data,2), skip(data,3));
                break;
            }
            return dst;
        }

        readonly ByteBlock4 Storage;

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0)
        {
            Storage = b0;
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
            Storage = Bytes.join(w32, b0, b1, b2, b3);
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
        public AsmOcValue(uint src)
        {
            Storage = src;
        }

        public ref readonly Hex8 FirstByte
        {
            [MethodImpl(Inline)]
            get => ref @as<Hex8>(this[0]);
        }

        public ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Storage[i];
        }

        public ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Storage[i];
        }

        [MethodImpl(Inline)]
        public uint ToScalar()
        {
            var dst = (uint)FirstByte;
            var sz = TrimmedSize;
            if(sz == 2)
                dst = @as<ushort>(Storage.Bytes);
            else if(sz == 3)
                dst = @as<uint>(Storage.Bytes);
            return dst;
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

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => Storage.Bytes;
        }

        public string Format()
            => format(this);

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
        public static implicit operator uint(AsmOcValue src)
            => src.Storage;

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(ReadOnlySpan<byte> src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(ByteBlock4 src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmOcValue a, AsmOcValue b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmOcValue a, AsmOcValue b)
            => !a.Equals(b);

        public static AsmOcValue Empty => default;
    }
}