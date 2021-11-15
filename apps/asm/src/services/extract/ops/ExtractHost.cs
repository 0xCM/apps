//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial class ApiExtractor
    {
        public ApiHostExtracts ExtractHost(in ResolvedHost src)
        {
            var dst = list<ApiMemberExtract>();
            var flow = Wf.Running(Msg.ExtractingHost.Format(src.Host));
            var methods = src.Methods.View;
            var count = methods.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                Buffer.Clear();
                dst.Add(ApiExtracts.extract(skip(methods,i), Buffer));
                counter++;
            }

            Wf.Ran(flow, Msg.ExtractedHost.Format(counter, src.Host));

            return new ApiHostExtracts(src.Host, dst.ToArray());
        }
    }
}