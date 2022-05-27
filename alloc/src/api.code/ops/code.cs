//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
    {
        static BinaryCode code(uint size, Index<CollectedEncoding> src)
        {
            var dst = alloc<byte>(size);
            var k = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var code = ref src[i].Code;
                for(var j=0; j<code.Length; j++, k++)
                    seek(dst,k) = code[j];
            }
            return dst;
        }
    }
}