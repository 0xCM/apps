//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiExtractor
    {
        uint ExtractPart(ResolvedPart src, IApiPack pack)
        {
            var hosts = src.Hosts.View;
            var count = (uint)hosts.Length;
            if(count == 0)
                return 0;

            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var extracted = ExtractHost(host, pack);
                counter += extracted.Routines.Count;
                DatasetReceiver.Add(extracted);
            }
            return counter;
        }

        public uint ExtractParts(ReadOnlySpan<ResolvedPart> src, IApiPack pack)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += ExtractPart(skip(src,i), pack);
            return counter;
        }
    }
}