//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly partial struct BfDatasets
    {
        public static ulong max(byte width)
            => width switch
            {
                0 => 0,
                1 => (ulong)Limits.Max1u,
                2 => (ulong)Limits.Max2u,
                3 => (ulong)Limits.Max3u,
                4 => (ulong)Limits.Max4u,
                5 => (ulong)Limits.Max6u,
                6 => (ulong)Limits.Max6u,
                7 => (ulong)Limits.Max7u,
                8 => (ulong)Limits.Max8u,
                9 => (ulong)Limits.Max9u,
                10 => (ulong)Limits.Max10u,
                11 => (ulong)Limits.Max11u,
                12 => (ulong)Limits.Max12u,
                13 => (ulong)Limits.Max13u,
                14 => (ulong)Limits.Max14u,
                15 => (ulong)Limits.Max15u,
                16 => (ulong)Limits.Max16u,
                17 => (ulong)Limits.Max17u,
                18 => (ulong)Limits.Max18u,
                19 => (ulong)Limits.Max19u,
                20 => (ulong)Limits.Max20u,
                21 => (ulong)Limits.Max21u,
                22 => (ulong)Limits.Max22u,
                23 => (ulong)Limits.Max23u,
                24 => (ulong)Limits.Max24u,
                32 => (ulong)Limits.Max32u,
                64 => (ulong)Limits.Max64u,

                _ => 0
            };


        /// <summary>
        /// Infers bitfield segment widths from an enum
        /// </summary>
        /// <typeparam name="W">The defining denum</typeparam>
        public static Index<byte> widths<W>()
            where W : unmanaged, Enum
                => Symbols.index<W>().Kinds.Map(x => bw8(x));
    }
}