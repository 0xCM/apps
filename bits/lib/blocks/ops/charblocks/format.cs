//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct CharBlocks
    {
        public static string format<T>(T src)
            where T : unmanaged, ICharBlock<T>
        {
            var length = (int)src.Capacity;
            var data = src.Data;
            Span<char> dst = stackalloc char[length];
            for(var i=0; i<length; i++)
                seek(dst,i) = Chars.Space;

            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(c != 0)
                    seek(dst,i) = c;
                else
                    break;
            }

            return new string(dst);
        }
    }
}