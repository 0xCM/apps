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
        uint ExtractPart(ResolvedPart src)
        {
            var hosts = src.Hosts.View;
            var count = (uint)hosts.Length;
            if(count == 0)
                return 0;

            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var extracted = ExtractHostDatast(host);
                counter += extracted.Routines.Count;
                DatasetReceiver.Add(extracted);
            }
            return counter;
        }

        public Task<uint> BeginExtractPart(ResolvedPart src)
            => run(() => ExtractPart(src));
    }
}