//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitGridEmitter;

    public class t_bg_patterns : t_bits<t_bg_patterns>
    {
        public void stripes_12x12()
            => export(GridPatterns.stripes(n256,n12,n12,z16));

        void bars_16x16()
            => export(GridPatterns.bars(n256,n16,n16,z16));

        void xcross_16x16()
            => export(BitGrid.xor(GridPatterns.stripes(n256, n16,n16,z16), GridPatterns.bars(n256, n16,n16,z16)));

        void exchange_rotl_4_16x16()
            => export(BitGrid.rotl(GridPatterns.exchange(n256,n16,n16,z16), 4));

        void exchange_rotr_4_16x16()
            => export(BitGrid.rotr(GridPatterns.exchange(n256,n16,n16,z16), 4));

        void identity_4x4()
            => export(GridPatterns.one(n16,n4,n4,z16));

        void identity_5x5()
            => export(GridPatterns.one(n32,n5,n5,z32));

        void identity_8x8()
            => export(GridPatterns.one(n64,n8,n8,z8));

        void identity_16x16()
            => export(GridPatterns.one(n256,n16,n16,z16));

        void exchange_16x16()
            => export(GridPatterns.exchange(n256,n16,n16,z16));

        void identity_rotl_4_16x16()
            => export(BitGrid.rotl(GridPatterns.one(n256,n16,n16,z16), 4));

        void identity_rotr_4_16x16()
            => export(BitGrid.rotr(GridPatterns.one(n256,n16,n16,z16), 4));
    }
}