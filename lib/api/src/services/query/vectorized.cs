//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        /// <summary>
        /// Queries the host for operations vectorized over 128-bit vectors
        /// </summary>
        /// <param name="w">The vector width</param>
        /// <param name="generic">Whether generic or non-generic methods should be selected</param>
        [Op]
        public static ApiHostMethods vectorized(IApiHost host, W128 w, GenericState g = default)
            => ApiHostMethods.load(host, g.IsGeneric() ? ApiHostMethods.load(host).Storage.VectorizedGeneric(w) : ApiHostMethods.load(host).Storage.VectorizedDirect(w));

        /// <summary>
        /// Queries the host for operations vectorized over 128-bit vectors
        /// </summary>
        /// <param name="w">The vector width</param>
        /// <param name="generic">Whether generic or non-generic methods should be selected</param>
        [Op]
        public static ApiHostMethods vectorized(IApiHost host, W256 w, GenericState g = default)
            => ApiHostMethods.load(host, g.IsGeneric() ? ApiHostMethods.load(host).Storage.VectorizedGeneric(w) : ApiHostMethods.load(host).Storage.VectorizedDirect(w));

        [Op, Closures(Closure)]
        public static ApiHostMethods vectorized<K>(IApiHost host, W128 w, K kind, GenericState g = default)
            where K : unmanaged
                => ApiHostMethods.load(host, classified(host,kind,g).Storage.VectorizedDirect(w));

        [Op, Closures(Closure)]
        public static ApiHostMethods vectorized<K>(IApiHost host, W256 w, K kind, GenericState g = default)
            where K : unmanaged
                => ApiHostMethods.load(host, classified(host,kind,g).Storage.VectorizedDirect(w));

        /// <summary>
        /// Queries the host for vectorized methods of specified vector width, name and generic partition
        /// </summary>
        /// <param name="w">The width to match</param>
        /// <param name="name">The name to match</param>
        /// <param name="g">The generic partition to consider</param>
        [Op]
        public static ApiHostMethods vectorized(IApiHost host, W128 w, string name, GenericState g = default)
            => ApiHostMethods.load(host, ApiHostMethods.load(host).Storage.Vectorized(w,name,g));

        /// <summary>
        /// Queries the host for vectorized methods of specified vector width, name and generic partition
        /// </summary>
        /// <param name="w">The width to match</param>
        /// <param name="name">The name to match</param>
        /// <param name="g">The generic partition to consider</param>
        [Op]
        public static ApiHostMethods vectorized(IApiHost host, W256 w, string name, GenericState g = default)
            => ApiHostMethods.load(host, ApiHostMethods.load(host).Storage.Vectorized(w,name,g));
    }
}