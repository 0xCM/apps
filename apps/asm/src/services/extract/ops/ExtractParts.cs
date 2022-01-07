//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading.Tasks;

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

        uint ExtractParts(ResolvedPart[] src, bool pll, IApiPack pack)
        {
            var flow = Running(Msg.ExtractingResolved.Format(src.Length));
            var counter = 0u;
            if(pll)
            {
                var tasks = src.Select(p => BeginExtractPart(p,pack));
                Task.WaitAll(tasks);
                iter(tasks, t => counter += t.Result);
            }
            else
            {
                counter = ExtractParts(src, pack);
            }
            Ran(flow, string.Format(Msg.ExtractedResolved.Format(counter)));

            return counter;
        }
    }
}