//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Bitsets
    {
        [MethodImpl(Inline)]
        public static Bitset128<T> init<T>(N128 n, params T[] src)
            where T : unmanaged
                => new Bitset128<T>(src);

        public static string format<T>(in Bitset128<T> src, string sep = ",", int pad = 0)
            where T : unmanaged
        {
            var dst = text.buffer();
            Span<T> kinds = stackalloc T[Bitset128<T>.Capacity];
            var count = src.Members(kinds);
            var slot = RP.slot(0,(sbyte)pad);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.AppendFormat(slot, skip(kinds,i).ToString());
            }
            return dst.Emit();
        }
    }

    public struct Bitset128<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        static ref readonly byte member(in T src)
            => ref @as<T,byte>(src);

        public const byte Capacity = 128;

        BitVector128<ulong> Data;

        [MethodImpl(Inline)]
        public Bitset128(ReadOnlySpan<T> src)
        {
            Data = default;
            var count = src.Length;
            for(byte i=0; i<count; i++)
            {
                ref readonly var m = ref member(skip(src,i));
                if(m != 0)
                    Data = Data.Enable(m);
            }
        }

        [MethodImpl(Inline)]
        public bit Contains(in T src)
            => Data.Test(member(src));

        [MethodImpl(Inline)]
        public Bitset128<T> Include(in T src)
        {
            ref readonly var m = ref member(src);
            if(m != 0)
                Data = Data.Enable(m);
            return this;
        }

        [MethodImpl(Inline)]
        public Bitset128<T> Clear(in T src)
        {
            Data = Data.Disable(member(src));
            return this;
        }

        [MethodImpl(Inline)]
        public Bitset128<T> Include(params T[] src)
        {
            for(var i=0; i<src.Length; i++)
                Include(skip(src,i));
            return this;
        }

        [MethodImpl(Inline)]
        public uint Members(Span<T> dst)
        {
            var counter = z8;
            var count = min(dst.Length,Capacity);
            for(byte i=1; i<count; i++)
            {
                if(Data.Test(i))
                    seek(dst,counter++) = @as<T>(i);
            }
            return counter;
        }

        [MethodImpl(Inline)]
        public uint Count()
        {
            var counter = z8;
            var count = Capacity;
            for(byte i=1; i<count; i++)
            {
                if(Data.Test(i))
                    counter++;
            }
            return counter;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.GetHashCode();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count() == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count() != 0;
        }

        public string Format()
            => Bitsets.format(this);

        public string Format(string sep, int pad = 0)
            => Bitsets.format(this, sep, pad);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(Bitset128<T> src)
            => Data.Equals(src.Data);

        public override bool Equals(object src)
            => src is Bitset128<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static bool operator==(Bitset128<T> a, Bitset128<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(Bitset128<T> a, Bitset128<T> b)
            => !a.Equals(b);
    }
}