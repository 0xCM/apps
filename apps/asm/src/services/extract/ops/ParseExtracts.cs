//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class ApiExtractor
    {
        ApiMemberBlocks ParseExtracts(ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = src.Length;
            var buffer = alloc<ApiMemberCode>(count);
            ref var parsed = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                ref var output = ref seek(parsed,i);
                if(Parser.Parse(input, out output))
                    Channel.Raise(new MemberParsedEvent(input,output));
                else
                    Wf.Error(string.Format("Extract parse failure for {0}", input.Member.OpUri));

            }
            return buffer;
        }
    }
}