//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Collections.Generic;

    using static Root;
    using static core;

    partial struct ApiRuntimeLoader
    {
        /// <summary>
        /// Describes an api host
        /// </summary>
        /// <param name="part">The defining part</param>
        /// <param name="type">The reifying type</param>
        [Op]
        public static IApiHost apihost(Type type)
            => apihost(type.Assembly.Id(), type);

        /// <summary>
        /// Returns the hosts found in a specified component
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static Index<IApiHost> apihosts(Assembly src)
        {
            var id = src.Id();
            return ApiHostTypes(src).Select(h => apihost(id, h));
        }

        /// <summary>
        /// Returns the hosts found in a specified component set
        /// </summary>
        /// <param name="src">The source components</param>
        public static ReadOnlySpan<IApiHost> apihosts(ReadOnlySpan<Assembly> src)
        {
            var dst = list<IApiHost>();
            for(var i=0; i<src.Length; i++)
                iter(apihosts(skip(src,i)), h => dst.Add(h));
            return dst.ViewDeposited();
        }

        /// <summary>
        /// Describes an api host
        /// </summary>
        /// <param name="part">The defining part</param>
        /// <param name="t">The reifying type</param>
        [Op]
        static IApiHost apihost(PartId part, Type type)
        {
            var uri = ApiHostUri.from(type);
            var declared = type.DeclaredMethods();
            return new ApiHost(type, uri.HostName, part, uri, declared, index(declared));
        }

        [Op]
        static Dictionary<string,MethodInfo> index(Index<MethodInfo> methods)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(methods, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
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