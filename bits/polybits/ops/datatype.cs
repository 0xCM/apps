//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Type datatype(in asci64 src)
        {
            var w = datawidth(src);
            var dst = typeof(void);
            if(w <= 8)
                dst = typeof(byte);
            else if(w <= 16)
                dst = typeof(ushort);
            else if(w <= 32)
                dst = typeof(uint);
            else if(w <= 64)
                dst = typeof(ulong);
            else if(w <= 128)
                dst = typeof(BitVector128<ulong>);
            else
                Throw.message("Width unsupported");
            return dst;
        }
    }
}