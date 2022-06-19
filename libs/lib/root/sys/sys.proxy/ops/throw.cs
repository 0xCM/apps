//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using K = ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(K.Throw)]
        public static void @throw(string msg)
            => throw new Exception(msg);

        [MethodImpl(Options), Opaque(K.Throw)]
        public static void @throw(string msg, string caller, int? line, string path)
            => throw new Exception(string.Format("{0}:{1} {2} {3}",msg, caller, line, path));

        [MethodImpl(Options), Opaque(K.Throw)]
        public static T @throw<T>(object msg)
            => throw new Exception(msg?.ToString() ?? EmptyString);

        [MethodImpl(Options), Opaque(K.Throw)]
        public static void @throw(Exception e)
            => throw e;

        [MethodImpl(Options), Opaque(K.Throw)]
        public static void @throw(object e)
            => throw new Exception($"{e}");

        [MethodImpl(Options), Opaque(K.Throw)]
        public static void @throw(Func<string> f)
            => throw new Exception(f());

        [MethodImpl(Options), Opaque(K.Throw), Closures(Closure)]
        public static T @throw<T>(Exception e)
            => throw e;
    }
}