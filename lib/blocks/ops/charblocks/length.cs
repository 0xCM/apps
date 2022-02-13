//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct CharBlocks
    {
        [MethodImpl(Inline)]
        public static int length<T>(in T src)
            where T : unmanaged, ICharBlock<T>
        {
            var data = src.Data;
            var counter = 0;
            var max = data.Length;
            for(var i=0; i<max; i++)
            {
                if(skip(data,i) == 0)
                    break;
                counter++;
            }
            return counter;
        }
    }
}