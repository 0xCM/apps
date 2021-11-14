//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class t_bv_bitparts : t_bits<t_bv_bitparts>
    {
        public void bv_bitparts_32x16()
        {
            Span<BitVector16> dst = stackalloc BitVector16[2];
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                BitVector.pack16x2(x, dst);
                Claim.eq(dst[0], x.Lo);
                Claim.eq(dst[1], x.Hi);
            }
        }

    }
}
