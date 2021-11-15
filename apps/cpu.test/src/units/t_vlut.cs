
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vlut : t_inx<t_vlut>
    {
        public void lut16_rep_check()
        {
            var w = w128;
            var src = gcpu.vinc<byte>(w);
            var lut = VLut.init(src);
            var content = gcpu.vinc<byte>(w, 64);
            var selected =  VLut.select(lut,content);
            Claim.veq(content, selected);
        }

        public void lut32_rep_check()
        {
            var w = w256;
            var src = gcpu.vinc<byte>(w);
            var lut = VLut.init(src);
            var content = gcpu.vinc<byte>(w, 64);
            var selected =  VLut.select(lut,content);
            Claim.veq(content, selected);
        }
    }
}