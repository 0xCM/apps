//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    [ApiHost]
    public readonly struct ClrJit
    {
        [Op]
        public static ApiMember member(MethodInfo src, ApiHostUri host)
        {
            var uri = ApiIdentity.define(ApiUriScheme.Located, host, src.Name, MultiDiviner.Service.Identify(src));
            var address = jit(src);
            return new ApiMember(uri, src, address, ClrDynamic.msil(address, uri, src));
        }

        [Op]
        public static ApiMember member(MethodInfo src, OpUri uri)
        {
            var address = ClrJit.jit(src);
            return new ApiMember(uri, src, address, ClrDynamic.msil(address, uri, src));
        }

        [Op]
        public static ApiMember member(in ResolvedMethod src)
            => new ApiMember(src.Uri, src.Method, src.EntryPoint, ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method));

        // [Op]
        // public static ApiMembers members(Index<ApiMember> src)
        // {
        //     if(src.Count != 0)
        //         return new ApiMembers(src.First.BaseAddress, src.Sort());
        //     else
        //         return ApiMembers.Empty;
        // }

        // [Op]
        // public static ApiMembers members(MemoryAddress @base, Index<ApiMember> src)
        // {
        //     if(src.Length != 0)
        //         return new ApiMembers(@base, src.Sort());
        //     else
        //         return ApiMembers.Empty;
        // }

        [Op]
        static Index<ApiMember> members(JittedMethod[] src)
        {
            var count = src.Length;
            var dst = sys.alloc<ApiMember>(count);
            var diviner = MultiDiviner.Service;
            for(var i=0; i<count; i++)
            {
                var member = src[i];
                var method = member.Method;
                var id = diviner.Identify(method);
                var uri = ApiIdentity.define(ApiUriScheme.Located, member.Host, method.Name, id);
                dst[i] = new ApiMember(uri, method, member.Location, ClrDynamic.msil(member.Location, uri, method));
            }

            return dst;
        }

        [Op]
        public static ApiMembers jit(IApiCatalog catalog, IWfEventTarget log)
        {
            var @base = Process.GetCurrentProcess().MainModule.BaseAddress;
            var parts = catalog.Parts;
            var kParts = parts.Length;
            var all = list<ApiMembers>();
            var total = 0u;
            foreach(var part in parts)
                all.Add(ClrJit.jit(part, log));

            return ApiQuery.members(all.SelectMany(x => x).Array());
        }

        [Op]
        public static ApiMembers jit(IPart src, IWfEventTarget log)
        {
            var buffer = list<ApiMember>();
            var catalog = ApiLoader.catalog(src.Owner);

            var types = catalog.ApiTypes;
            foreach(var t in types)
                buffer.AddRange(ClrJit.jit(t, log));

            var hosts = catalog.ApiHosts;
            foreach(var h in hosts)
                buffer.AddRange(ClrJit.members(h, log));

            return ApiQuery.members(buffer.ToArray());
        }

        [Op, MethodImpl(Inline)]
        static MemoryAddress fptr(MethodInfo src)
            => src.MethodHandle.GetFunctionPointer();

        [Op]
        public static ApiMembers jit(Index<ApiCompleteType> src, IWfEventTarget log)
        {
            var dst = list<ApiMember>();
            var count = src.Count;
            ref var lead = ref src.First;
            for(var i=0u; i<count; i++)
                dst.AddRange(jit(skip(lead,i), log));
            return ApiQuery.members(dst.ToArray());
        }

        [Op]
        static WarnEvent<T> warn<T>(T msg)
            => Events.warn(typeof(ClrJit), msg);

        [Op]
        public static MemoryAddress jit(MethodInfo src)
        {
            RuntimeHelpers.PrepareMethod(src.MethodHandle);
            return fptr(src);
        }

        [Op]
        public static void jit(ReadOnlySpan<MethodInfo> src, Span<MemoryAddress> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = jit(skip(src,i));
        }

        [Op]
        public static Index<MemberAddress> jit(Index<MethodInfo> src)
        {
            var methods = src.View;
            var count = methods.Length;
            var buffer = alloc<MemberAddress>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                var method = skip(methods, i);
                seek(dst,i) = Clr.address(method, jit(method));
            }
            return buffer;
        }

        [Op]
        public static MemoryAddress jit(Delegate src)
        {
            sys.prepare(src);
            return fptr(src.Method);
        }

        [Op]
        public static DynamicPointer jit(DynamicDelegate src)
        {
            sys.prepare(src.Operation);
            return ClrDynamic.pointer(src);
        }

        public static DynamicPointer jit<D>(DynamicDelegate<D> src)
            where D : Delegate
                => jit(src.Untyped);

        [Op]
        public static ApiMembers jit(IApiCatalog src, IWfEventTarget log, bool pll)
        {
            var dst = bag<ApiMembers>();
            iter(src.PartCatalogs(), catalog => dst.Add(jit(catalog,log)), pll);
            return ApiQuery.members(Process.GetCurrentProcess().MainModule.BaseAddress, dst.SelectMany(x => x).Array());
        }

        [Op]
        public static ApiMembers jit(ReadOnlySpan<Assembly> src, IWfEventTarget log, bool pll)
        {
            var @base = Process.GetCurrentProcess().MainModule.BaseAddress;
            var dst = bag<ApiMembers>();
            iter(src, part => dst.Add(jit(part,log)), pll);
            return ApiQuery.members(@base, dst.SelectMany(x => x).Array());
        }

        [Op]
        public static ApiMembers jit(IApiPartCatalog src, IWfEventTarget log)
        {
            var dst = list<ApiMember>();
            iter(src.ApiTypes.Select(h => h.HostType), t => dst.AddRange(complete(t,log)));
            iter(src.ApiHosts.Select(h => h.HostType), t => dst.AddRange(jit(t, log)));
            return ApiQuery.members(dst.ToArray());
        }

        [Op]
        public static ApiMembers jit(Assembly src, IWfEventTarget log)
            => jit(ApiLoader.catalog(src), log);

        [Op]
        public static MethodInfo[] complete(Type src, HashSet<string> exclusions)
            => src.DeclaredMethods().Unignored().NonGeneric().Exclude(exclusions);

        [Op]
        public static Index<ApiMember> complete(Type src, IWfEventTarget log)
            => members(complete(src, CommonExclusions).Select(m => new JittedMethod(src.ApiHostUri(), m, ClrJit.jit(m))));

        [Op]
        public static ApiMembers members(IApiHost src, IWfEventTarget log)
            => ApiQuery.members(direct(src).Concat(generic(src, log)).Array());

        [Op]
        public static void jit(IApiHost host, ConcurrentBag<ApiHostMembers> dst, IWfEventTarget log)
        {
            var jitted = jit(host, log);
            if(jitted.IsNonEmpty)
                dst.Add(jitted);
        }

        [Op]
        public static void jit(ApiCompleteType src, ConcurrentBag<ApiHostMembers> dst, IWfEventTarget log)
        {
            var jitted = ApiQuery.members(ClrJit.jit(src, log));
            if(jitted.IsNonEmpty)
                dst.Add(new ApiHostMembers(src.HostUri, jitted));
        }

        [Op]
        public static ApiHostMembers jit(IApiHost src, IWfEventTarget log)
        {
            var dst = list<ApiMember>();
            return new (src.HostUri, jit(src.HostType, log));
        }

        [Op]
        public static ApiMembers jit(Type src, IWfEventTarget log)
        {
            var direct = ClrJit.direct(src);
            var generic = ClrJit.generic(src, log);
            return ApiQuery.members(direct.Concat(generic).Array());
        }

        [Op]
        public static Index<ApiMember> jit(ApiCompleteType src, IWfEventTarget log)
            => members(complete(src.HostType, CommonExclusions).Select(m => new JittedMethod(src.HostUri, m, ClrJit.jit(m))));

        [Op]
        static ApiMember[] direct(IApiHost src)
            => direct(src.HostType);

        [Op]
        static ApiMember[] direct(Type src)
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

        static ApiMember[] generic(Type src, IWfEventTarget log)
        {
            var uri = src.ApiHostUri();
            var generic = ApiQuery.generic(src).Select(m => new JittedMethod(uri, m)).ToReadOnlySpan();
            var gCount = generic.Length;
            var buffer = list<ApiMember>();
            for(var i=0; i<gCount; i++)
                buffer.AddRange(ClrJit.generic(skip(generic, i), log));
            return buffer.ToArray();
        }

        static ApiMember[] generic(IApiHost src, IWfEventTarget log)
            => generic(src.HostType, log);

        [Op]
        static ApiMember[] generic(JittedMethod src, IWfEventTarget log)
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
                    var uri = ApiIdentity.define(ApiUriScheme.Located, src.Host, method.Name, diviner.Identify(constructed));
                    seek(dst,i) = member(constructed, uri);
                }
            }
            catch(ArgumentException e)
            {
                var msg = string.Format("{0}: Closure creation failed for {1}/{2}", e.GetType().Name, method.DeclaringType.DisplayName(), method.DisplayName());
                log.Deposit(warn(msg));
                return sys.empty<ApiMember>();
            }
            catch(Exception e)
            {
                log.Deposit(warn(e.ToString()));
            }
            return buffer;
        }

        static IDictionary<MethodInfo,Type> ClosureProviders(IEnumerable<Type> src)
        {
            var query = from t in src
                        from m in t.DeclaredStaticMethods()
                        let tag = m.Tag<ClosureProviderAttribute>()
                        where tag.IsSome()
                        select (m, tag.Value.ProviderType);
            return query.ToDictionary();
        }

        static HashSet<string> CommonExclusions
            = Algs.hashset(Algs.array("ToString","GetHashCode", "Equals", "ToString"));
    }
}