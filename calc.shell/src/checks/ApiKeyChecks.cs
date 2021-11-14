//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class ApiKeyChecks : AppService<ApiKeyChecks>
    {
        const GenericStateKind ng = GenericStateKind.Nongeneric;

        const GenericStateKind g = GenericStateKind.OpenGeneric;

        public void Run()
        {
            var kinds = Symbols.index<ApiClassKind>().View;
            var catalog = Wf.ApiCatalog;
            var hosts = @readonly(catalog.ApiHosts);
            var parts = @readonly(catalog.Parts);
            var count = hosts.Length;

            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts, i);
                var hosted = ApiQuery.operators(host, n2, ng);
                var opcount = hosted.Length;
                var methods = hosted.View;

                for(var j=0; j<opcount; j++)
                {
                    ref readonly var method = ref skip(methods,j);
                    var @class = ApiQuery.apiclass(method);
                    var key = ApiKeys.key(host.PartId, (ushort)host.HostType.MetadataToken, @class);

                    var sig = method.Definition.DisplaySig();
                    var output = string.Format("{0} | {1,-12} | {2}", ApiKeyFormats.bitfield(key), @class, sig);
                    Wf.Row(output);
                }
            }
        }
    }
}