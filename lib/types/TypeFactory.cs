//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Specs = TypeSyntax;
    using SK = ScalarClass;

    [ApiHost]
    public readonly struct TypeFactory
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

        [MethodImpl(Inline), Op]
        public static ScalarType c()
            => scalar(Specs.c(0).Text, SK.C, 0, 0);

        [MethodImpl(Inline), Op]
        public static ScalarBitSeqType bits(uint content, NativeSize storage)
            => new ScalarBitSeqType(content,storage);

        [MethodImpl(Inline), Op]
        public static NaturalType natural(ulong value)
            => new NaturalType(value);

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

        public static string format(FunctionType src)
        {
            var dst = text.buffer();
            dst.Append(src.Name);
            dst.AppendFormat("[{0}]", src.KindName);
            dst.Append(":");
            var operands = src.Operands;
            var count = operands.Count;
            for(var i=0; i<count; i++)
            {
                dst.Append(operands[i].Format());
                if(i != count - 1)
                    dst.Append(" -> ");
            }
            return dst.Emit();
        }

        [Formatter]
        public static string format(PrimalCellType src)
        {
            var dst = EmptyString;
            if(src.ContentWidth == src.StorageWidth)
                dst = string.Format("{0}{1}", src.ContentWidth, TypeFactory.format(src.Kind));
            else
                dst = string.Format("({0}:{1}){2}", src.ContentWidth, src.StorageWidth, TypeFactory.format(src.Kind));
            return dst;
        }

        [Parser]
        public static Outcome parse(string src, out PrimalCellType dst)
        {
            var input = text.trim(src);
            var result = Outcome.Failure;
            dst = PrimalCellType.Empty;
            if(text.empty(input))
                return result;

            var length = input.Length;
            var q = length - 1;

            var i = text.index(input, Chars.Colon);
            if(!PrimitiveParser.parse(input, out var pc))
                return result.Fail;

            if(i >= 0)
            {
                var l = text.index(input,Chars.LParen);
                var r = text.index(input,Chars.RParen);
                if(l >= 0 && r>=0)
                {
                    var b = text.inside(input,l,r);
                    var k = text.index(b, Chars.Colon);
                    if(k >=0)
                    {
                        var cw = text.left(b,k);
                        var sw = text.right(b,k);
                        if(uint.TryParse(cw, out var ncw))
                        {
                            if(uint.TryParse(sw, out var nsw))
                            {
                                var c = text.right(input,r);
                                dst = new PrimalCellType(ncw,nsw,pc);
                                result = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if(q != 0)
                {
                    if(uint.TryParse(text.left(input, q), out var n))
                    {
                        dst = new PrimalCellType(n,n,pc);
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}