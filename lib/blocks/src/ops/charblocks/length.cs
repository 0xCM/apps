//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    readonly partial struct CharBlocks
    {
        [MethodImpl(Inline)]
        public static int length<T>(in T src)
            where T : unmanaged, ICharBlock<T>
        {
            var data = src.Data;
            var counter = 0;
            var max = src.Capacity;
            for(var i=0; i<max; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(c == 0)
                    break;
                counter++;
            }
            return counter;
        }
    }
}