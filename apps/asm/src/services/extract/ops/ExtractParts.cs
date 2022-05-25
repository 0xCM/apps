//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiExtractor
    {
        public uint ExtractParts(ReadOnlySpan<ResolvedPart> src, IApiPack pack)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += ExtractPart(skip(src,i), pack);
            return counter;
        }

        // uint ExtractParts(ResolvedPart[] src, IApiPack pack)
        // {
        //     var flow = Running(Msg.ExtractingResolved.Format(src.Length));
        //     var counter = 0u;
        //     counter = ExtractParts(src, pack);
        //     Ran(flow, string.Format(Msg.ExtractedResolved.Format(counter)));
        //     return counter;
        // }
    }
}