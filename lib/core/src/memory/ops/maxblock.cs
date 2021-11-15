//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op]
        public static MemoryBlock maxblock(ReadOnlySpan<MemoryBlock> src)
        {
            var max = MemoryBlock.Empty;
            var count = src.Length;
            if(count == 0)
                return max;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(src,i);
                if(block.Size > max.Size)
                    max = block;
            }
            return max;
        }
    }
}