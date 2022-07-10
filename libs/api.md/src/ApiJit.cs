//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    public sealed class ApiJit : AppService<ApiJit>
    {
        public static ApiMember member(in ResolvedMethod src)
            => new ApiMember(src.Uri, src.Method, src.EntryPoint, ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method));

        public ApiMembers JitCatalog()
            => JitCatalog(Wf.ApiParts.Catalog);

        public ApiMembers JitCatalog(IApiCatalog catalog)
        {
            var @base = Process.GetCurrentProcess().MainModule.BaseAddress;
            var parts = catalog.Parts;
            var kParts = parts.Length;
            var flow = Wf.Running(Msg.JittingParts.Format(kParts));
            var all = list<ApiMembers>();
            var total = 0u;
            foreach(var part in parts)
                all.Add(JitPart(part));

            var members = ApiMembers.create(all.SelectMany(x => x).Array());
            Wf.Ran(flow, Msg.JittedParts.Format(members.Count, parts.Length));
            return members;
        }

        public static ApiMembers jit(IApiCatalog src, WfEventLogger log, bool pll)
        {
            var dst = bag<ApiMembers>();
            iter(src.PartCatalogs(), catalog => dst.Add(jit(catalog,log)), pll);
            return ApiMembers.create(Process.GetCurrentProcess().MainModule.BaseAddress, dst.SelectMany(x => x).Array());
        }

        public static ApiMembers jit(ReadOnlySpan<Assembly> src, WfEventLogger log, bool pll)
        {
            var @base = Process.GetCurrentProcess().MainModule.BaseAddress;
            var dst = bag<ApiMembers>();
            iter(src, part => dst.Add(jit(part,log)), pll);
            return ApiMembers.create(@base, dst.SelectMany(x => x).Array());
        }

        public static ApiMembers jit(IApiPartCatalog src, WfEventLogger log)
        {
            var dst = list<ApiMember>();
            iter(src.ApiTypes.Select(h => h.HostType), t => dst.AddRange(complete(t,log)));
            iter(src.ApiHosts.Select(h => h.HostType), t => dst.AddRange(jit(t, log)));
            return ApiMembers.create(dst.ToArray());
        }

        public static ApiMembers jit(Assembly src, WfEventLogger log)
            => jit(ApiLoader.catalog(src), log);

        public static Index<ApiMember> complete(Type src, WfEventLogger log)
            => Members(ApiQuery.complete(src, CommonExclusions).Select(m => new JittedMethod(src.ApiHostUri(), m, ClrJit.jit(m))));

        public static ApiHostMembers jit(IApiHost src, WfEventLogger log)
        {
            var dst = list<ApiMember>();
            return new (src.HostUri, jit(src.HostType, log));
        }

        public static ApiMembers jit(Type src, WfEventLogger log)
        {
            var direct = JitDirect(src);
            var generic = JitGeneric(src, log);
            return ApiMembers.create(direct.Concat(generic).Array());
        }

        public static Index<ApiMember> jit(ApiCompleteType src, WfEventLogger log)
            => Members(ApiQuery.complete(src.HostType, CommonExclusions).Select(m => new JittedMethod(src.HostUri, m, ClrJit.jit(m))));

        public ApiMembers JitHost(IApiHost src)
        {
            var direct = JitDirect(src);
            var generic = JitGeneric(src, EventLog);
            return ApiMembers.create(direct.Concat(generic).Array());
        }

        public ApiMembers Jit(Index<ApiCompleteType> src)
        {
            var dst = list<ApiMember>();
            var count = src.Count;
            ref var lead = ref src.First;
            for(var i=0u; i<count; i++)
                dst.AddRange(jit(skip(lead,i), EventLog));
            return ApiMembers.create(dst.ToArray());
        }

        public ApiMembers JitPart(IPart src)
        {
            var flow = Running(Msg.JittingPart.Format(src.Id));
            var buffer = list<ApiMember>();
            var catalog = ApiLoader.catalog(src.Owner);
            var types = catalog.ApiTypes;
            var hosts = catalog.ApiHosts;

            foreach(var t in types)
                buffer.AddRange(jit(t, EventLog));

            foreach(var h in hosts)
                buffer.AddRange(JitHost(h));

            var members = ApiMembers.create(buffer.ToArray());
            Ran(flow, Msg.JittedPart.Format(members.Count, src.Id));

            return members;
        }

        // public Index<ApiMember> Jit(ApiCompleteType src)
        //     => jit(src, EventLog);

        public IDictionary<MethodInfo,Type> ClosureProviders(IEnumerable<Type> src)
        {
            var query = from t in src
                        from m in t.DeclaredStaticMethods()
                        let tag = m.Tag<ClosureProviderAttribute>()
                        where tag.IsSome()
                        select (m, tag.Value.ProviderType);
            return query.ToDictionary();
        }

        static ApiMember[] JitDirect(IApiHost src)
            => JitDirect(src.HostType);

        public static ApiMember member(MethodInfo src, ApiHostUri host)
        {
            var uri = ApiUri.define(ApiUriScheme.Located, host, src.Name, MultiDiviner.Service.Identify(src));
            var address = ClrJit.jit(src);
            return new ApiMember(uri, src, address, ClrDynamic.msil(address, uri, src));
        }

        public static ApiMember member(MethodInfo src, OpUri uri)
        {
            var address = ClrJit.jit(src);
            return new ApiMember(uri, src, address, ClrDynamic.msil(address, uri, src));
        }

        static ApiMember[] JitDirect(Type src)
        {
            var uri = src.ApiHostUri();
            var methods = ApiQuery.nongeneric(src).Select(m => new JittedMethod(uri,  m));
            var count = methods.Length;
            var buffer = alloc<ApiMember>(count);
            var diviner = MultiDiviner.Service;
            for(var i=0; i<count; i++)
                seek(buffer,i) = member(methods[i].Method, uri);
            return buffer;
        }

        static ApiMember[] JitGeneric(Type src, WfEventLogger log)
        {
            var uri = src.ApiHostUri();
            var generic = ApiQuery.generic(src).Select(m => new JittedMethod(uri, m)).ToReadOnlySpan();
            var gCount = generic.Length;
            var buffer = list<ApiMember>();
            for(var i=0; i<gCount; i++)
                buffer.AddRange(JitGeneric(skip(generic,i),log));
            return buffer.ToArray();
        }

        static ApiMember[] JitGeneric(IApiHost src, WfEventLogger log)
            => JitGeneric(src.HostType, log);

        static ApiMember[] JitGeneric(JittedMethod src, WfEventLogger log)
        {
            var diviner = MultiDiviner.Service;
            var method = src.Method;
            var types = @readonly(ApiIdentityKinds.NumericClosureTypes(method));
            var count = types.Length;
            var buffer = alloc<ApiMember>(count);
            var dst = span(buffer);
            try
            {
                for(var i=0u; i<count; i++)
                {
                    ref readonly var t = ref skip(types, i);
                    var constructed = src.Method.MakeGenericMethod(t);
                    //var address = ClrJit.jit(constructed);
                    //var id = diviner.Identify(constructed);
                    var uri = ApiUri.define(ApiUriScheme.Located, src.Host, method.Name, diviner.Identify(constructed));
                    //seek(dst,i) = new ApiMember(uri, constructed, address);
                    seek(dst,i) = member(constructed, uri);
                }
            }
            catch(ArgumentException e)
            {
                var msg = string.Format("{0}: Closure creation failed for {1}/{2}", e.GetType().Name, method.DeclaringType.DisplayName(), method.DisplayName());
                log(warn(msg));
                return sys.empty<ApiMember>();
            }
            catch(Exception e)
            {
                log(warn(e.ToString()));
            }
            return buffer;
        }

        static Index<ApiMember> Members(JittedMethod[] src)
        {
            var count = src.Length;
            var dst = sys.alloc<ApiMember>(count);
            var diviner = MultiDiviner.Service;
            for(var i=0; i<count; i++)
            {
                var member = src[i];
                var method = member.Method;
                var id = diviner.Identify(method);
                var uri = ApiUri.define(ApiUriScheme.Located, member.Host, method.Name, id);
                dst[i] = new ApiMember(uri, method, member.Location, ClrDynamic.msil(member.Location, uri, method));
            }

            return dst;
        }

        static HashSet<string> CommonExclusions
            = core.hashset(core.array("ToString","GetHashCode", "Equals", "ToString"));
    }
}