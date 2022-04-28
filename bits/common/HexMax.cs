//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HexMax
    {
        [MethodImpl(Inline)]
        public static Hex1 max(N1 n)
            => Hex1.MaxValue;

        [MethodImpl(Inline)]
        public static Hex2 max(N2 n)
            => Hex2.MaxValue;

        [MethodImpl(Inline)]
        public static Hex3 max(N3 n)
            => Hex3.MaxValue;

        [MethodImpl(Inline)]
        public static Hex4 max(N4 n)
            => Hex4.MaxValue;

        [MethodImpl(Inline)]
        public static Hex5 max(N5 n)
            => Hex5.MaxValue;

        [MethodImpl(Inline)]
        public static Hex6 max(N6 n)
            => Hex6.MaxValue;

        [MethodImpl(Inline)]
        public static Hex7 max(N7 n)
            => Hex7.MaxValue;

        [MethodImpl(Inline)]
        public static Hex8 max(N8 n)
            => Hex8.MaxValue;

        [MethodImpl(Inline)]
        public static Hex10 max(N10 n)
            => Hex10.MaxValue;

        [MethodImpl(Inline)]
        public static Hex12 max(N12 n)
            => Hex12.MaxValue;

        [MethodImpl(Inline)]
        public static Hex14 max(N14 n)
            => Hex14.MaxValue;

        [MethodImpl(Inline)]
        public static Hex16 max(N16 n)
            => Hex16.MaxValue;

        [MethodImpl(Inline)]
        public static Hex32 max(N32 n)
            => Hex32.MaxValue;

        [MethodImpl(Inline)]
        public static Hex64 max(N64 n)
            => Hex64.MaxValue;

        public static Hex64 max(byte n)
            => n switch
            {
                1 => (ulong)Hex1.Max,
                2 => (ulong)Hex2.Max,
                3 => (ulong)Hex3.Max,
                4 => (ulong)Hex4.Max,
                5 => (ulong)Hex5.Max,
                6 => (ulong)Hex6.Max,
                7 => (ulong)Hex7.Max,
                8 => (ulong)Hex8.Max,
                10 => Hex10.Max,
                12 => Hex12.Max,
                14 => Hex14.Max,
                16 => (ulong)Hex16.Max,
                32 => (ulong)Hex32.Max,
                64 => Hex64.Max,

                _ => Hex64.Zero
            };
    }
}