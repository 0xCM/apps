//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiExtractor
    {
        public uint ExtractParts(ReadOnlySpan<ResolvedPart> src, IApiPack dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += ExtractPart(skip(src,i), dst);
            return counter;
        }

        public uint ExtractPart(in ResolvedPart src, IApiPack dst)
        {
            var count = (uint)src.Hosts.Count;
            if(count == 0)
                return 0;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var extracted = ExtractHost(src.Hosts[i], dst);
                counter += extracted.Routines.Count;
                DatasetReceiver.Add(extracted);
            }
            return counter;
        }
    }
}