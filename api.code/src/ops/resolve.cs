//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        /// <summary>
        /// Resolves a specified method
        /// </summary>
        /// <param name="src">The source method</param>
        public static ResolvedMethod resolve(MethodInfo src)
        {
            var diviner = MultiDiviner.Service;
            var host = ApiHostUri.from(src.DeclaringType);
            var uri = ApiUri.define(ApiUriScheme.Located, host, src.Name, diviner.Identify(src));
            var resolved = new ResolvedMethod(src, uri, ClrJit.jit(src));
            return resolved;
        }
    }
}