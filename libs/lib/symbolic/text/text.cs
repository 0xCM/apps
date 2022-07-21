//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class TextFormat
    {
        [Op]
        public static string adjacent(dynamic a, dynamic b)
            => string.Format(RP.Adjacent2, a, b);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c)
            => string.Format(RP.Adjacent3, a, b, c);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d)
            => string.Format(RP.Adjacent4, a, b, c, d);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e)
            => string.Format(RP.Adjacent5, a, b, c, d, e);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e, dynamic f)
            => string.Format(RP.Adjacent6, a, b, c, d, e, f);
    }

    [ApiHost]
    public static partial class text
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// An abbreviation for the ridiculously long "StringComparison.InvariantCultureIgnoreCase"
        /// </summary>
        public const StringComparison NoCase = StringComparison.InvariantCultureIgnoreCase;

        /// <summary>
        /// An abbreviation for the somewhat verbose "StringComparison.InvariantCulture"
        /// </summary>
        public const StringComparison Cased = StringComparison.InvariantCulture;

        [MethodImpl(Inline)]
        public static string format<T>(T src)
            => Formatters.Service.Format(src);

        [MethodImpl(Inline)]
        public static string format<T,K>(T src, K selector)
            where K : unmanaged
                => Formatters.Service.Format(src, selector);

        [MethodImpl(Inline)]
        public static IFormatter Formatter(Type type)
            => Formatters.Service.FirstOrDefault(type);

        [MethodImpl(Inline)]
        public static IFormatter Formatter<K>(Type type, K selector)
            where K : unmanaged
                => Formatters.Service.RefinedOrDefault(type, selector);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(IFormatter<T> src)
            => Formatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K,T>(IFormatter<T> src, K selector)
            where K : unmanaged
                => Formatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(IFormatter<object> src)
            => Formatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K>(IFormatter<object> src, K selector)
            where K : unmanaged
                => Formatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(RenderDelegate<T> src)
            => Formatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K,T>(RenderDelegate<T> src, K selector)
            where K : unmanaged
                => Formatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(Type type, RenderDelegate<object> src)
            => Formatters.Service.Register(type, z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K>(Type type, K selector, RenderDelegate<object> src)
            where K : unmanaged
                => Formatters.Service.Register(type, selector, src);

        class Formatters
        {
            public static Formatters Service => Instance;

            readonly struct Formatter : IFormatter<object>
            {
                public RenderDelegate<object> Delegate {get;}

                [MethodImpl(Inline)]
                public Formatter(RenderDelegate<object> f)
                {
                    Delegate = f;
                }

                [MethodImpl(Inline)]
                public string Format(object src)
                    => Delegate(src);
            }

            readonly struct Formatter<T> : IFormatter<T>
            {
                public RenderDelegate<T> Delegate {get;}

                [MethodImpl(Inline)]
                public Formatter(RenderDelegate<T> f)
                {
                    Delegate = f;
                }

                [MethodImpl(Inline)]
                public string Format(T src)
                    => Delegate(src);
            }

            [MethodImpl(Inline)]
            public string Format<T>(T src)
                => FirstOrDefault(typeof(T)).Format(src);

            [MethodImpl(Inline)]
            public string Format<K,T>(T src, K selector)
                where K : unmanaged
                    => RefinedOrDefault(typeof(T), selector).Format(src);

            [MethodImpl(Inline)]
            static ulong key<K>(Type type, K selector)
                where K : unmanaged
            {
                var token = (uint)type.MetadataToken;
                var part = type.Assembly.Id();
                return (ulong)token | ((ulong)part << 32) | ((ulong)bw16(selector) << 38);
            }

            [MethodImpl(Inline)]
            static string @default(object src)
                => src?.ToString();

            [MethodImpl(Inline)]
            public IFormatter RefinedOrDefault<K>(Type type, K selector)
                where K : unmanaged
            {
                if(Lookup.TryGetValue(key(type,selector), out var dst))
                    return dst;
                else
                    return new Formatter(@default);
            }

            [MethodImpl(Inline)]
            public IFormatter FirstOrDefault(Type type)
            {
                if(Lookup.TryGetValue(key(type,z16), out var dst))
                    return dst;
                else
                    return new Formatter(@default);
            }

            [MethodImpl(Inline)]
            public bool Register<K,T>(K selector, IFormatter<T> formatter)
                where K : unmanaged
                => Lookup.TryAdd(key(typeof(T),selector), formatter);

            [MethodImpl(Inline)]
            public bool Register<K,T>(K selector, RenderDelegate<T> formatter)
                where K : unmanaged
                    => Lookup.TryAdd(key(typeof(T),selector), new Formatter<T>(formatter));

            [MethodImpl(Inline)]
            public bool Register<K>(Type type, K selector, RenderDelegate<object> formatter)
                where K : unmanaged
                    => Lookup.TryAdd(key(type,selector), new Formatter(formatter));

            ConcurrentDictionary<ulong, IFormatter> Lookup;

            Formatters()
            {
                Lookup = new();
            }

            static Formatters Instance;

            static Formatters()
            {
                Instance = new();
            }
        }
    }
}