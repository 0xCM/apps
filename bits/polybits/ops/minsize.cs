//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline), Op]
        public static NativeSize minsize(in asci64 src)
        {
            var width = datawidth(src);
            if(width <= 8)
                return NativeSizeCode.W8;
            else if(width <= 16)
                return NativeSizeCode.W16;
            else if(width <= 32)
                return NativeSizeCode.W32;
            else if(width <= 64)
                return NativeSizeCode.W64;
            else if(width <= 128)
                return NativeSizeCode.W128;
            else
                Throw.message("Width unsupported");

            return default;
        }
    }
}