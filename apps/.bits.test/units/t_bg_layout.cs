//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_bg_layout : t_bits<t_bg_layout>
    {
        public void bg_layout_21x32x32()
        {
            var a0 = CellCalcs.gridspec(n21,n32,0u);
            var b0 = CellCalcs.gridspec(21, 32, 32);
            Claim.eq(a0,b0);

            var a1 = CellCalcs.gridspec(n32,n64,ushort.MinValue);
            var b1 = CellCalcs.gridspec(32, 64, 16);
            Claim.eq(a1,b1);

            var a2 = CellCalcs.gridspec(n5,n15,byte.MinValue);
            var b2 = CellCalcs.gridspec(5, 15, 8);
            Claim.eq(a2,b2);
        }
    }
}