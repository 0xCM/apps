//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct TS
    {
        const NumericKind Closure = UnsignedInts;

        internal static string format(ClrPrimitiveKind src)
            => src.ToString().ToLower();

        public static ScalarType @char<T>(T t)
            where T : unmanaged, IEquatable<T>, ISizedType
        {
            var spec = CanonicalSpecs.ct((byte)t.StorageWidth,t);
            return new ScalarType<T>(spec.Text,ScalarClass.C, t);
        }

        [Op]
        public static ScalarType @char(BitWidth n)
        {
            switch((byte)n)
            {
                case 8:
                    return scalar(CanonicalSpecs.c(8).Text, ScalarClass.C, 8,8);
                case 16:
                    return scalar(CanonicalSpecs.c(16).Text, ScalarClass.C, 16,16);
                case 32:
                    return scalar(CanonicalSpecs.c(32).Text, ScalarClass.C, 32,32);
            }
            return ScalarType.Empty;
        }

        [MethodImpl(Inline), Op]
        public static ScalarType scalar(Identifier name, ScalarClass @class, BitWidth content, BitWidth storage)
            => new ScalarType(name,@class,content,storage);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypeKind<K> kind<K>(K key, Identifier name, byte arity = 0)
            where K : unmanaged
                => new TypeKind<K>(key, name, arity);

        [MethodImpl(Inline), Op]
        public static TypeKind kind(ulong key, Identifier @class, Identifier name, byte arity = 0)
            => new TypeKind(key, @class, name, arity);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypeKind untype<K>(TypeKind<K> src)
            where K : unmanaged
                => src;

        [MethodImpl(Inline)]
        public static TypeAlias<T> alias<T>(T type, Identifier alias)
            where T : IType
                => new TypeAlias<T>(type,alias);

        [MethodImpl(Inline), Op]
        public static TypeAlias alias(IType type, Identifier alias)
            => new TypeAlias(type, alias);
    }
}