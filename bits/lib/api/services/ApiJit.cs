//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    using static core;

    [ApiHost]
    public sealed class ApiJit : AppService<ApiJit>
    {
        [Op]
        public ApiMembers JitCatalog()
            => JitCatalog(Wf.ApiParts.Catalog);

        public ApiMembers JitCatalog(IApiCatalog catalog)
        {
            var @base = Runtime.CurrentProcess.BaseAddress;
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

        public ApiMembers JitHost(IApiHost src)
        {
            var direct = JitDirect(src);
            var generic = JitGeneric(src);
            return ApiMembers.create(direct.Concat(generic).Array());
        }

        public ApiMembers Jit(Index<ApiCompleteType> src)
        {
            var dst = list<ApiMember>();
            var count = src.Count;
            var exclusions = CommonExclusions;
            ref var lead = ref src.First;
            for(var i=0u; i<count; i++)
                dst.AddRange(Jit(skip(lead,i), exclusions));
            return ApiMembers.create(dst.ToArray());
        }

        public ApiMembers JitPart(IPart src)
        {
            var flow = Wf.Running(Msg.JittingPart.Format(src.Id));
            var buffer = list<ApiMember>();
            var catalog = ApiRuntimeLoader.catalog(src);
            var types = catalog.ApiTypes;
            var hosts = catalog.ApiHosts;

            foreach(var t in types)
                buffer.AddRange(Jit(t));

            foreach(var h in hosts)
                buffer.AddRange(JitHost(h));

            var members = ApiMembers.create(buffer.ToArray());
            Wf.Ran(flow, Msg.JittedPart.Format(members.Count, src.Id));

            return members;
        }

        public Index<ApiMember> Jit(ApiCompleteType src)
            => Jit(src, CommonExclusions);

        [Op]
        ApiMember[] Jit(ApiCompleteType src, HashSet<string> exclusions)
            => Members(ApiQuery.methods(src,exclusions).Select(m => new JittedMethod(src.HostUri, m, ClrJit.jit(m))));

        [Op]
        ApiMember[] Members(JittedMethod[] located)
        {
            var count = located.Length;
            var dst = sys.alloc<ApiMember>(count);
            for(var i=0; i<count; i++)
            {
                var member = located[i];
                var method = member.Method;
                var id = Diviner.Identify(method);
                var uri = ApiUri.define(ApiUriScheme.Located, member.Host, method.Name, id);
                dst[i] = new ApiMember(uri, method, member.Location);
            }

            return dst;
        }

        IMultiDiviner Diviner
            => MultiDiviner.Service;

        [Op]
        ApiMember[] JitDirect(IApiHost src)
        {
            var methods = ApiQuery.nongeneric(src).Select(m => new JittedMethod(src.HostUri, m));
            var count = methods.Length;
            var buffer = alloc<ApiMember>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                var m = methods[i];
                var id = Diviner.Identify(m.Method);
                var uri = ApiUri.define(ApiUriScheme.Located, src.HostUri, m.Method.Name, id);
                seek(dst,i) = new ApiMember(uri, m.Method, ClrJit.jit(m.Method));

            }
            return buffer;
        }

        [Op]
        ApiMember[] JitGeneric(IApiHost src)
        {
            var generic = ApiQuery.generic(src).Select(m => new JittedMethod(src.HostUri, m)).ToReadOnlySpan();
            var gCount = generic.Length;
            var buffer = list<ApiMember>();
            for(var i=0; i<gCount; i++)
                buffer.AddRange(JitGeneric(skip(generic,i)));
            return buffer.ToArray();
        }

        [Op]
        ApiMember[] JitGeneric(JittedMethod src)
        {
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
                    var address = ClrJit.jit(constructed);
                    var id = Diviner.Identify(constructed);
                    var uri = ApiUri.define(ApiUriScheme.Located, src.Host, method.Name, id);
                    seek(dst,i) = new ApiMember(uri, constructed, address);
                }
            }
            catch(ArgumentException e)
            {
                var msg = string.Format("{0}: Closure creation failed for {1}/{2}", e.GetType().Name, method.DeclaringType.DisplayName(), method.DisplayName());
                Wf.Warn(msg);
                return sys.empty<ApiMember>();
            }
            catch(Exception e)
            {
                Wf.Warn(e.ToString());
            }
            return buffer;
        }

        public IDictionary<MethodInfo,Type> ClosureProviders(IEnumerable<Type> src)
        {
            var query = from t in src
                        from m in t.DeclaredStaticMethods()
                        let tag = m.Tag<ClosureProviderAttribute>()
                        where tag.IsSome()
                        select (m, tag.Value.ProviderType);
            return query.ToDictionary();
        }

        static HashSet<string> CommonExclusions
            => core.hashset(core.array("ToString","GetHashCode", "Equals", "ToString"));
    }
}