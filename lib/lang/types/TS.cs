//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Specs = TypeSpecs;
    using SK = ScalarClass;

    [ApiHost]
    public readonly struct TS
    {
        const NumericKind Closure = UnsignedInts;

        [Formatter]
        public static string format(ClrPrimitiveKind src)
            => src.ToString().ToLower();

        public static DiscreteRefinement<T,V> refinement<T,V>(Identifier name, T type, params V[] values)
            where T : IType
                => new DiscreteRefinement<T,V>(name, type, values);

        [MethodImpl(Inline)]
        public static LiteralType<V> literal<V>(Identifier name, V value)
            where V : IScalarValue
                => new LiteralType<V>(name, value);

        [MethodImpl(Inline), Op]
        public static LiteralType<@string> literal(Identifier name, @string value)
            => new LiteralType<@string>(name, value);

        [MethodImpl(Inline), Op]
        public static FunctionType function(Identifier name, ulong kind, Operand[] operands, Operand ret, Facets? facets = null)
            => new FunctionType(name, kind, operands, ret, facets ?? Facets.Empty);

        [MethodImpl(Inline), Op]
        public static FunctionType<K> function<K>(Identifier name, K kind, Operand[] operands, Operand ret, Facets? facets = null)
            where K : unmanaged
                => new FunctionType<K>(name, kind, operands, ret, facets ?? Facets.Empty);

        public static ScalarType c<T>(T t)
            where T : unmanaged, IEquatable<T>, ISizedType
                => new ScalarType<T>(Specs.ct((byte)t.StorageWidth,t).Text, SK.C, t);

        [MethodImpl(Inline), Op]
        public static ScalarType c()
            => scalar(Specs.c(0).Text, SK.C, 0, 0);

        [Op]
        public static ScalarType c(BitWidth n)
        {
            switch((byte)n)
            {
                case 8:
                    return scalar(Specs.c(8).Text, SK.C, 8,8);
                case 16:
                    return scalar(Specs.c(16).Text, SK.C, 16,16);
                case 32:
                    return scalar(Specs.c(32).Text, SK.C, 32,32);
            }
            return ScalarType.Empty;
        }

        [MethodImpl(Inline), Op]
        public static ScalarType u()
            => scalar(Specs.u(0).Text, SK.U, 0, 0);

        [MethodImpl(Inline), Op]
        public static ScalarType i()
            => scalar(Specs.u(0).Text, SK.I, 0, 0);

        [MethodImpl(Inline), Op]
        public static ScalarType u(BitWidth n, BitWidth t)
            => scalar(Specs.u(n).Text, SK.U, n, t);

        [MethodImpl(Inline), Op]
        public static ScalarType i(BitWidth n, BitWidth t)
            => scalar(Specs.u(n).Text, SK.I, n, t);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SizedType<K> sized<K>(Identifier name, K kind, BitWidth content, BitWidth storage)
            where K : unmanaged
                => new SizedType<K>(name,kind,content,storage);

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