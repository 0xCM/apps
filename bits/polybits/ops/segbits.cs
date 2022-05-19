//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PolyBits
    {
        public static string segbits<T>(T src, BfInterval interval)
            where T : unmanaged
        {
            var dw = core.width<T>();
            var bits = EmptyString;
            var offset = dw - interval.Width;
            if(dw == 8)
                bits = bw8(src).FormatBits();
            if(dw == 16)
                bits = bw16(src).FormatBits();
            else if(dw == 32)
                bits = bw32(src).FormatBits();
            else if(dw == 64)
                bits = bw64(src).FormatBits();
            return text.format(slice(span(bits), offset));
        }
    }
}