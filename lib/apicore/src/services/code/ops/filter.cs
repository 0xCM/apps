//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct ApiCodeBlocks
    {
        public static ReadOnlySpan<ApiMemberCode> filter(ReadOnlySpan<ApiMemberCode> src, ApiClassKind kind)
        {
            var count = src.Length;
            var dst = list<ApiMemberCode>();
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code.KindId == kind)
                    dst.Add(code);
            }
            return dst.ViewDeposited();
        }
    }
}