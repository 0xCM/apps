//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ByteBlocks
    {
        [MethodImpl(Inline)]
        public static bool empty<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
        {
            var b = src.Bytes;
            var count = b.Length;
            var empty = true;
            for(var i=0; i<count; i++)
            {
                if(skip(b,i) != 0)
                {
                    empty=false;
                    break;
                }
            }
            return empty;
        }
    }
}