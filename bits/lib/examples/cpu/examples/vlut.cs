//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Examples
{
    partial struct vExamples
    {
        public void vlut(W128 w)
        {
            // lut := <0,1,2,...,15> ; defines 16 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,79>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }

        public void vlut(W256 w)
        {
            // lut := <0,1,2,...,31>  ; defines 32 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,95>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }
    }
}