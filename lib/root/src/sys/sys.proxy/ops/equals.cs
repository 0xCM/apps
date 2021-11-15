//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using O = ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(O.Equals)]
        public static bool equals(object a, object b)
            => object.Equals(a,b);

        [MethodImpl(Options), Opaque(O.Equals), Closures(Closure)]
        public static bool equals<T>(T a, T b)
            where T : struct
                => a.Equals(b);

        [MethodImpl(Options), Opaque(O.Equals)]
        public static bool equals(string a, string b)
            => a.Equals(b);

        [MethodImpl(Options), Opaque(O.Equals)]
        public static bool equals(string a, string b, StringComparison options)
            => a.Equals(b,options);
    }
}