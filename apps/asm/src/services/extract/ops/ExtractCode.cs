//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiExtractor
    {
        ApiHostDataset ExtractHostDatast(in ResolvedHost src, IApiPack pack)
        {
            var code = CodeExtractor.ExtractHostCode(src, pack, PackArchive);
            return CreateDataset(code, EmitRoutines(code));
        }

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
                var extracted = ExtractHostDatast(host, pack);
                counter += extracted.Routines.Count;
                DatasetReceiver.Add(extracted);
            }
            return counter;
        }
    }
}