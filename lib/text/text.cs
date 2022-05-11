//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
        public static string format<T>(T src, ushort selector)
            => Formatters.Service.Format(src, selector);

        [MethodImpl(Inline)]
        public static IFormatter Formatter(Type type)
            => Formatters.Service.FirstOrDefault(type);

        [MethodImpl(Inline)]
        public static IFormatter Formatter(Type type, ushort selector)
            => Formatters.Service.RefinedOrDefault(type, selector);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(IFormatter<T> src)
            => Formatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(IFormatter<T> src, ushort selector)
            => Formatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(IFormatter<object> src)
            => Formatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(IFormatter<object> src, ushort selector)
            => Formatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(FormatterDelegate<T> src)
            => Formatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(FormatterDelegate<T> src, ushort selector)
            => Formatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(Type type, FormatterDelegate<object> src)
            => Formatters.Service.Register(type, z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(Type type, ushort selector, FormatterDelegate<object> src)
            => Formatters.Service.Register(type, selector, src);

        class Formatters
        {
            public static Formatters Service => Instance;

            readonly struct Formatter : IFormatter<object>
            {
                public FormatterDelegate<object> Delegate {get;}

                [MethodImpl(Inline)]
                public Formatter(FormatterDelegate<object> f)
                {
                    Delegate = f;
                }

                [MethodImpl(Inline)]
                public string Format(object src)
                    => Delegate(src);
            }

            readonly struct Formatter<T> : IFormatter<T>
            {
                public FormatterDelegate<T> Delegate {get;}

                [MethodImpl(Inline)]
                public Formatter(FormatterDelegate<T> f)
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
            public string Format<T>(T src, ushort selector)
                => RefinedOrDefault(typeof(T), selector).Format(src);

            [MethodImpl(Inline)]
            static ulong key(Type type, ushort selector)
            {
                var token = (uint)type.MetadataToken;
                var part = type.Assembly.Id();
                return (ulong)token | ((ulong)part << 32) | ((ulong)selector << 38);
            }

            [MethodImpl(Inline)]
            static string @default(object src)
                => src?.ToString();

            // [MethodImpl(Inline)]
            // public bool Match(Type type, out IFormatter f)
            //     => Lookup.TryGetValue(key(type,z16), out f);

            // [MethodImpl(Inline)]
            // public bool Match(Type type, ushort selector, out IFormatter f)
            //     => Lookup.TryGetValue(key(type, selector), out f);

            [MethodImpl(Inline)]
            public IFormatter RefinedOrDefault(Type type, ushort selector)
            {
                if(Lookup2.TryGetValue(type, out var dst))
                    return dst;
                else
                    return new Formatter(@default);
            }

            [MethodImpl(Inline)]
            public IFormatter FirstOrDefault(Type type)
            {
                if(Lookup2.TryGetValue(type, out var dst))
                    return dst;
                else
                    return new Formatter(@default);
            }

            [MethodImpl(Inline)]
            public bool Register<T>(ushort selector, IFormatter<T> formatter)
                => Lookup2.TryAdd(typeof(T), formatter);

            [MethodImpl(Inline)]
            public bool Register(Type type, ushort selector, IFormatter<object> formatter)
                => Lookup2.TryAdd(type, formatter);

            [MethodImpl(Inline)]
            public bool Register<T>(ushort selector, FormatterDelegate<T> formatter)
                => Lookup2.TryAdd(typeof(T), new Formatter<T>(formatter));

            [MethodImpl(Inline)]
            public bool Register(Type type, ushort selector, FormatterDelegate<object> formatter)
                => Lookup2.TryAdd(type,new Formatter(formatter));

            //ConcurrentDictionary<ulong, IFormatter> Lookup;

            ConcurrentDictionary<Type, IFormatter> Lookup2;

            Formatters()
            {
                //Lookup = new();
                Lookup2 = new();
            }

            static Formatters Instance;

            static Formatters()
            {
                Instance = new();
            }
        }
    }
}