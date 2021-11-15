//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    using static Root;
    using static core;

    public class ApiRuntime : AppService<ApiRuntime>
    {
        const string RenderPattern = "{0,-16} | {1,-112} | {2, -82} | {3}";

        ApiJit ApiJit;

        protected override void OnInit()
        {
            ApiJit = Wf.ApiJit();
        }

        public static string format(in ApiRuntimeMember src)
            => string.Format(RenderPattern, src.Address, src.Uri, src.DisplaySig, src.Msil.CliCode.Format());

        /// <summary>
        /// Returns a <see cref='ApiHostCatalog'/> for a specified host
        /// </summary>
        /// <param name="wf">The workflow context</param>
        /// <param name="src">The host type</param>
        public ApiHostCatalog HostCatalog(Type src)
            => HostCatalog(ApiRuntimeLoader.apihost(src));

        /// <summary>
        /// Returns a <see cref='ApiHostCatalog'/> for a specified host
        /// </summary>
        /// <param name="wf">The workflow context</param>
        /// <param name="src">The host type</param>
        [Op]
        public ApiHostCatalog HostCatalog(IApiHost src)
        {
            var flow = Wf.Running(Msg.CreatingHostCatalog.Format(src.HostUri));
            var members = ApiJit.JitHost(src);
            var result = members.Length == 0 ? ApiHostCatalog.Empty : new ApiHostCatalog(src, members);
            Wf.Ran(flow, Msg.CreatedHostCatalog.Format(src.HostUri, members.Count));
            return result;
        }

        public Index<ApiRuntimeMember> EmitRuntimeIndex()
        {
            try
            {
                var hosts = Wf.ApiCatalog.ApiHosts;
                var kHost = (uint)hosts.Length;
                var members = RuntimeMembers();
                var view  = members.View;
                var target = Db.IndexFile("api.members");
                var flow = Wf.EmittingFile(target);
                using var writer = target.Writer();
                var count = view.Length;
                for(var i=0; i<count; i++)
                    writer.WriteLine(format(skip(view,i)));
                Wf.EmittedFile(flow, count);
                return members;
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return Index<ApiRuntimeMember>.Empty;
            }
        }

        public Index<ApiRuntimeMember> RuntimeMembers()
        {
            var hosts = @readonly(Wf.ApiCatalog.ApiHosts);
            var kHost = (uint)hosts.Length;
            var buffer = list<ApiRuntimeMember>();
            var flow = Wf.Running(Msg.IndexingHosts.Format(kHost));

            var counter = 0u;
            for(var i=0; i<kHost; i++)
            {
                var host = skip(hosts,i);
                var hostcat = HostCatalog(host);
                var component = host.HostType.Assembly;
                var members = @readonly(hostcat.Members.Storage);
                var apicount = (uint)members.Length;
                if(apicount != 0)
                {
                    for(var j=0u; j<apicount; j++, counter++)
                    {
                        var member = default(ApiRuntimeMember);
                        fill(host, skip(members,j), ref member);
                        buffer.Add(member);
                    }

                    Wf.Status(Msg.IndexedHost.Format(hostcat.Host.HostUri, apicount, counter));
                }
            }

            Wf.Ran(flow);

            return buffer.OrderBy(x => x.Address).Array();
        }

        static ref ApiRuntimeMember fill(IApiHost host, ApiMember src, ref ApiRuntimeMember dst)
        {
            var method = src.Method;
            dst.Address = src.BaseAddress;
            dst.Uri = src.OpUri;
            dst.DisplaySig = Clr.display(method.Artifact());
            dst.Msil = src.Msil;
            return ref dst;
        }
    }
}