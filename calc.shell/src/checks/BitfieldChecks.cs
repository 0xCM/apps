//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitfieldSpecs;

    public class BitfieldChecks : AppService<BitfieldChecks>
    {
        enum BF_A : byte
        {
            [Symbol("seg0")]
            Seg0 = 0,

            [Symbol("seg1")]
            Seg1 = 1,

            [Symbol("seg2")]
            Seg2 = 2,

            [Symbol("seg3")]
            Seg3 = 3
        }

        public void bitfield_a()
        {
            var segs = segments(
                segment(0, BF_A.Seg0, 0, 2),
                segment(1, BF_A.Seg1, 2, 2),
                segment(2, BF_A.Seg2, 4, 2),
                segment(3,BF_A.Seg3, 6, 2)
                );

            var s0 = (byte)0b01_11_10_11;
            var field = Bitfields.create(segs,s0);
            var specs = field.SegSpecs;
            var count = specs.Length;
            var buffer = text.buffer();
            buffer.Append("[");
            for(byte i=0; i<count; i++)
            {
                ref readonly var seg = ref skip(specs,i);
                var state = field.Read(i);
                var j=0u;

                var bitstring = BitRender.gformat(state, (byte)seg.Width);
                buffer.Append(string.Format("{0}={1}",seg.Format(), bitstring));
                if(i !=count -1)
                    buffer.Append(" | ");
            }
            buffer.Append("]");
            Wf.Row(buffer.Emit());
        }

        public void Run()
        {
            bitfield_a();
        }
    }
}