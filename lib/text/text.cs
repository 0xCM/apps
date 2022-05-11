//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Text;

    using static Root;

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

        public static bool RegisterFormatter(Type type, Func<object,string> src)
            => Formatters.Service.Register(type, z16, src);

        public static bool RegisterFormatter(Type type, ushort selector, Func<object,string> src)
            => Formatters.Service.Register(type, selector, src);

        class Formatters
        {
            public static Formatters Service => Instance;

            [MethodImpl(Inline)]
            public string Format<T>(T src)
                => FirstOrDefault(typeof(T))(src);

            [MethodImpl(Inline)]
            public string Format<T>(T src, ushort selector)
                => RefinedOrDefault(typeof(T), selector)(src);

            [MethodImpl(Inline)]
            static ulong key(Type type, ushort selector)
            {
                var token = (uint)type.MetadataToken;
                var part = type.Assembly.Id();
                return (ulong)token | ((ulong)part << 32) | ((ulong)selector << 38);
            }

            [MethodImpl(Inline)]
            static string @default(object src) => src?.ToString();

            [MethodImpl(Inline)]
            public bool Match(Type type, out Func<object,string> f)
                => Lookup.TryGetValue(key(type,z16), out f);

            [MethodImpl(Inline)]
            public bool Match(Type type, ushort selector, out Func<object,string> f)
                => Lookup.TryGetValue(key(type, selector), out f);

            [MethodImpl(Inline)]
            public Func<object,string> RefinedOrDefault(Type type, ushort selector)
            {
                if(Lookup.TryGetValue(key(type, selector), out var dst))
                    return dst;
                else
                    return @default;
            }

            [MethodImpl(Inline)]
            public Func<object,string> FirstOrDefault(Type type)
            {
                if(Lookup.TryGetValue(key(type, z16), out var dst))
                    return dst;
                else
                    return @default;
            }

            [MethodImpl(Inline)]
            public bool Register(Type type, ushort selector, Func<object,string> formatter)
                => Lookup.TryAdd(key(type,selector),formatter);

            ConcurrentDictionary<ulong, Func<object,string>> Lookup;

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