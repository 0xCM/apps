//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct sys
    {
        [MethodImpl(Options), Op]
        public static T @throw<T>([CallerName] string caller = null, [CallerLine] int? line = null, [CallerFile] string? path = null)
        {
            proxy.@throw("Something bad happened", caller, line, path);
            return default;
        }

        [MethodImpl(Options), Op]
        public static void @throw(string msg)
            => proxy.@throw(msg);

        [MethodImpl(Options), Op]
        public static void @throw(string msg, string caller, int? line, string path)
            => proxy.@throw(msg, caller, line, path);

        [MethodImpl(Options), Op]
        public static void @throw(Exception e)
            => proxy.@throw(e);

        [MethodImpl(Options), Op]
        public static void @throw(Func<string> f)
            => proxy.@throw(f);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T @throw<T>(Exception e)
            => proxy.@throw<T>(e);

        [MethodImpl(Options), Op]
        public static T @throw<T>(object msg)
            => proxy.@throw<T>(msg);
    }
}