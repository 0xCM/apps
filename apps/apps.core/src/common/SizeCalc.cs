//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct SizeCalc<T>
    {
        [MethodImpl(Inline)]
        public static int calc()
            => Unsafe.SizeOf<T>();
    }

    public readonly struct SizeCalc
    {
        public static ByteSize size(Type src)
        {
            var type = typeof(SizeCalc<>).MakeGenericType(src);
            var method = first(type.StaticMethods().Public());
            return (int)method.Invoke(null, sys.empty<object>());
        }

        public static BitWidth width(Type src)
            => size(src);

        public static ByteSize size<T>()
            => size(typeof(T));

        public static BitWidth width<T>()
            => size<T>();
    }
}