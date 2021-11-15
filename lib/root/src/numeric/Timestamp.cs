//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Timestamp : IDataTypeComparable<Timestamp>
    {
        public const string FormatPattern = "yyyy-MM-dd.HH.mm.ss.fff";

        [MethodImpl(Inline)]
        public static Timestamp now()
            => DateTime.Now;

        [MethodImpl(Inline), Op]
        public static Timestamp ticks(ulong ticks)
            => new Timestamp(ticks);

        [MethodImpl(Inline), Op]
        public static Timestamp ticks(long ticks)
            => new Timestamp((ulong)ticks);

        readonly ulong Ticks;

        [MethodImpl(Inline)]
        public Timestamp(ulong ticks)
            => Ticks = ticks;

        [MethodImpl(Inline)]
        public string Format()
            => new DateTime((long)Ticks).ToString(FormatPattern);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Timestamp src)
            => Ticks == src.Ticks;

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => src is Timestamp x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(Timestamp src)
            => Ticks.CompareTo(src.Ticks);

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Ticks != 0;
        }

        public uint Hashed
        {
            [MethodImpl(Inline)]
            get => FastHash.calc(Ticks);
        }

        public override int GetHashCode()
            => (int)Hashed;

        [MethodImpl(Inline)]
        public static implicit operator ulong(Timestamp src)
            => src.Ticks;

        [MethodImpl(Inline)]
        public static implicit operator Timestamp(DateTime src)
            => new Timestamp((ulong)src.Ticks);

        [MethodImpl(Inline)]
        public static bool operator <(Timestamp a, Timestamp b)
            => a.Ticks < b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <=(Timestamp a, Timestamp b)
            => a.Ticks <= b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >(Timestamp a, Timestamp b)
            => a.Ticks > b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >=(Timestamp a, Timestamp b)
            => a.Ticks >= b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator ==(Timestamp a, Timestamp b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Timestamp a, Timestamp b)
            => !a.Equals(b);

        public static Timestamp Zero => default;
    }
}