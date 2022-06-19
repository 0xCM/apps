//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Root
    {
        public static ArgumentException badarg<T>(T arg)
            => new ArgumentException(arg?.ToString() ?? "<null>");

        internal static T @throw<T>([CallerName] string caller = null, [CallerLine] int? line = null, [CallerFile] string? path = null)
            => throw new Exception();

        public static NotSupportedException no<T>()
            => new NotSupportedException($"The type {typeof(T).Name} is not supported");

        public static T no<S,T>([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Unsupported.raise<S,T>(caller, file, line);

        [MethodImpl(Inline)]
        public static bool found(int i)
            => i != NotFound;

        [MethodImpl(Inline)]
        public static int foundnot(int i, int alt)
            => found(i) ? i : alt;
    }
}