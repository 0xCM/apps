//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial struct ApiLoader
    {
        // [Op]
        // public static IApiHost host(Type type)
        //     => host(type.Assembly.Id(), type);

        /// <summary>
        /// Returns the hosts found in a specified component
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static Index<IApiHost> hosts(Assembly src)
        {
            var id = src.Id();
            return ApiHostTypes(src).Select(h => host(id, h));
        }

        // public static ReadOnlySpan<IApiHost> hosts(ReadOnlySpan<Assembly> src)
        // {
        //     var dst = list<IApiHost>();
        //     for(var i=0; i<src.Length; i++)
        //         iter(hosts(skip(src,i)), h => dst.Add(h));
        //     return dst.ViewDeposited();
        // }

        /// <summary>
        /// Describes an api host
        /// </summary>
        /// <param name="part">The defining part</param>
        /// <param name="t">The reifying type</param>
        [Op]
        static IApiHost host(PartId part, Type type)
        {
            var uri = ApiIdentity.host(type);
            var declared = type.DeclaredMethods();
            return new ApiHost(type, uri.HostName, part, uri, declared, index(declared));
        }

        [Op]
        static Dictionary<string,MethodInfo> index(Index<MethodInfo> src)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(src, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }

        /// <summary>
        /// Searches an assembly for types tagged with the <see cref="ApiHostAttribute"/>
        /// </summary>
        /// <param name="src">The assembly to search</param>
        [Op]
        static Index<Type> ApiHostTypes(Assembly src)
            => src.GetTypes().Where(IsApiHost);

        [Op]
        static bool IsApiHost(Type src)
            => src.Tagged<ApiHostAttribute>();
    }
}