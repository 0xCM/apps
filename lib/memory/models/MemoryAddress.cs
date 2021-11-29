//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public unsafe readonly struct MemoryAddress : IAddress<MemoryAddress,ulong>
    {
        public ulong Location {get;}

        [MethodImpl(Inline)]
        public MemoryAddress(ulong absolute)
            => Location = absolute;

        [MethodImpl(Inline)]
        public MemoryAddress(void* pSrc)
            => Location = (ulong)pSrc;

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Location == 0;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => Location != 0;
        }

        public bool IsNonZero
        {
             [MethodImpl(Inline)]
             get => Location != 0;
        }

        public Address32 Lo
        {
            [MethodImpl(Inline)]
            get => (uint)Location;
        }

        public Address32 Hi
        {
            [MethodImpl(Inline)]
            get => (uint)(Location >> 32);
        }

        [MethodImpl(Inline)]
        public Address16 Quadrant(N0 n)
            => Lo.Lo;

        [MethodImpl(Inline)]
        public Address16 Quadrant(N1 n)
            => Lo.Hi;

        [MethodImpl(Inline)]
        public Address16 Quadrant(N2 n)
            => Hi.Lo;

        [MethodImpl(Inline)]
        public Address16 Quadrant(N3 n)
            => Hi.Hi;

        public string Format()
            => Location.ToString("x") + HexFormatSpecs.PostSpec;

        public string Format(bool postspec)
            => postspec ? Format() : Location.ToString("x");

        public string FormatMinimal()
            => Location.FormatTrimmedAsmHex();

        public string Format(byte pad)
            => Location.FormatAsmHex(pad);

        [MethodImpl(Inline)]
        public int CompareTo(MemoryAddress src)
            => Location == src.Location ? 0 : Location < src.Location ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(MemoryAddress src)
            => Location == src.Location;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Location;
        }

        [MethodImpl(Inline)]
        public unsafe ref T Ref<T>()
            => ref Unsafe.AsRef<T>((void*)Location);

        [MethodImpl(Inline)]
        public unsafe void* Pointer()
            => (void*)Location;

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is MemoryAddress a && Equals(a);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public unsafe T* Pointer<T>()
            where T : unmanaged
                => (T*)Location;

        [MethodImpl(Inline)]
        public ref T As<T>()
        {
            var pSrc = Pointer();
            return ref @as<T>(pSrc);
        }

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(void* pSrc)
            => new MemoryAddress(pSrc);

        [MethodImpl(Inline)]
        public static explicit operator char*(MemoryAddress src)
            => (char*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator sbyte*(MemoryAddress src)
            => (sbyte*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator byte*(MemoryAddress src)
            => (byte*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator short*(MemoryAddress src)
            => (short*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ushort*(MemoryAddress src)
            => (ushort*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator int*(MemoryAddress src)
            => (int*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator uint*(MemoryAddress src)
            => (uint*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator long*(MemoryAddress src)
            => (long*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ulong*(MemoryAddress src)
            => (ulong*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator void*(MemoryAddress src)
            => (void*)src.Location;

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(IntPtr src)
            => new MemoryAddress((ulong)src.ToInt64());

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(UIntPtr src)
            => new MemoryAddress(src.ToUInt64());

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(MemoryAddress src)
            => (IntPtr)src.Location;

        [MethodImpl(Inline)]
        public static implicit operator long(MemoryAddress src)
            => (long)src.Location;

        [MethodImpl(Inline)]
        public static implicit operator ulong(MemoryAddress src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(ulong src)
            => new MemoryAddress(src);

        [MethodImpl(Inline)]
        public static explicit operator MemoryAddress(long src)
            => new MemoryAddress((ulong)src);

        [MethodImpl(Inline)]
        public static explicit operator MemoryAddress(int src)
            => new MemoryAddress((uint)src);

        [MethodImpl(Inline)]
        public static explicit operator MemoryAddress(ushort src)
            => new MemoryAddress(src);

        [MethodImpl(Inline)]
        public static explicit operator MemoryAddress(short src)
            => new MemoryAddress((ushort)src);

        [MethodImpl(Inline)]
        public static explicit operator ushort(MemoryAddress src)
            => (ushort)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator uint(MemoryAddress src)
            => (uint)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(MemoryAddress src)
            => new ByteSize((ulong)src.Location);

        [MethodImpl(Inline)]
        public static bool operator==(MemoryAddress a, MemoryAddress b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(MemoryAddress a, MemoryAddress b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator<(MemoryAddress a, MemoryAddress b)
            => a.Location < b.Location;

        [MethodImpl(Inline)]
        public static bool operator>(MemoryAddress a, MemoryAddress b)
            => a.Location > b.Location;

        [MethodImpl(Inline)]
        public static bool operator<=(MemoryAddress a, MemoryAddress b)
            => a.Location <= b.Location;

        [MethodImpl(Inline)]
        public static bool operator>=(MemoryAddress a, MemoryAddress b)
            => a.Location >= b.Location;

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, MemoryAddress b)
            => new MemoryAddress(a.Location + b.Location);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, byte* b)
            => new MemoryAddress(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, ushort* b)
            => new MemoryAddress(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, uint* b)
            => new MemoryAddress(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, ulong* b)
            => new MemoryAddress(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, void* b)
            => new MemoryAddress(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, ByteSize b)
            => new MemoryAddress(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, byte size)
            => new MemoryAddress(a.Location + size);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, ushort size)
            => new MemoryAddress(a.Location + size);

        [MethodImpl(Inline)]
        public static MemoryAddress operator++(MemoryAddress a)
            => new MemoryAddress(a.Location + 1);

        [MethodImpl(Inline)]
        public static MemoryAddress operator--(MemoryAddress a)
            => new MemoryAddress(a.Location - 1);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, uint size)
            => new MemoryAddress(a.Location + size);

        [MethodImpl(Inline)]
        public static MemoryAddress operator+(MemoryAddress a, ulong size)
            => new MemoryAddress(a.Location + size);

        [MethodImpl(Inline)]
        public static MemoryAddress operator-(MemoryAddress a, MemoryAddress b)
            => new MemoryAddress(a.Location - b.Location);

        public static MemoryAddress Zero
            => new MemoryAddress(0);
    }
}