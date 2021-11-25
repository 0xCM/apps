//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using Expr;

    using static Root;
    using static core;

    public enum LiteralNameSource : byte
    {
        None = 0,

        Identifier,

        Expression,
    }

    [ApiHost("expr.api")]
    public readonly partial struct expr
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Operand<T> operand<T>(Label name, T value)
            => new Operand<T>(name, value);

        public static TextExpr textexpr(string body)
            => new TextExpr(body);

        public static Index<Operand> operands<T>(T src)
            where T : struct
        {
            var props = @readonly(typeof(T).DeclaredInstanceProperties());
            var fields = @readonly(typeof(T).DeclaredInstanceFields());

            var _ref = __makeref(src);
            var propcount = props.Length;
            var fieldcount = fields.Length;
            var count = propcount + fieldcount;
            var buffer = alloc<Operand>(count);
            ref var dst = ref first(buffer);
            var j=0u;
            for(var i=0; i<propcount; i++)
            {
                ref readonly var prop = ref skip(props,i);
                seek(dst,j++) = new Operand(prop.Name, prop.GetValue(src));
            }
            for(var i=0; i<fieldcount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j++) = new Operand(field.Name, field.GetValue(src));
            }

            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static OpExprSpec spec(ExprScope scope, Label opname, IExpr[] operands)
            => new OpExprSpec(scope,opname,operands);

        [MethodImpl(Inline), Op]
        public static ExprSpec spec(ExprScope scope, IExpr[] operands, IExprComposer composer)
            => new ExprSpec(scope,operands,composer);

        [MethodImpl(Inline), Op]
        public static Var var(Label name, Type t, Func<IExpr> resolver)
            => new Var(name, t, resolver);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Var<T> var<T>(Label name, Func<T> resolver)
            => new Var<T>(name,resolver);

        /// <summary>
        /// Defines a scalar range expression
        /// </summary>
        /// <param name="min">The minimum scalar in the range</param>
        /// <param name="max">The maximum scalar in the range</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SeqRange<T> range<T>(Value<T> min, Value<T> max)
            => new SeqRange<T>(min, max);

        /// <summary>
        /// Creates a global scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(Label name)
            => new ExprScope(Label.Empty, name);

        /// <summary>
        /// Creates a child scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(Label parent, Label name)
            => new ExprScope(parent,name);

        /// <summary>
        /// Creates a <see cref='Constant{T}'/>
        /// </summary>
        /// <param name="name">The constant identifier</param>
        /// <typeparam name="T">The constant type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Value<T> value<T>(T src)
            => src;

        static Label name<E>(Sym<E> sym, LiteralNameSource src)
            where E : unmanaged
            => src switch{
                LiteralNameSource.Expression => sym.Expr.Text,
                LiteralNameSource.Identifier => sym.Name.Text,
                _ => sym.Name.Text
            };

        public static LiteralSeq<E> literals<E>(LiteralNameSource ns)
            where E : unmanaged, Enum
        {
            var src = Symbols.index<E>();
            var symbols = src.View;
            var count = symbols.Length;
            var dst = alloc<Literal<E>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(symbols, i);
                seek(dst,i) = literal<E>(name(s,ns), s.Kind);
            }
            return new LiteralSeq<E>(typeof(E).Name, dst);
        }

        [MethodImpl(Inline), Op]
        public static Literal<bit> literal(in Label name, bit value)
            => literal<bit>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<bool> literal(in Label name, bool value)
            => literal<bool>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<byte> literal(in Label name, byte value)
            => literal<byte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ushort> literal(in Label name, ushort value)
            => literal<ushort>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<uint> literal(in Label name, uint value)
            => literal<uint>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ulong> literal(in Label name, ulong value)
            => literal<ulong>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<sbyte> literal(in Label name, sbyte value)
            => literal<sbyte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<short> literal(in Label name, short value)
            => literal<short>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<int> literal(in Label name, int value)
            => literal<int>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<long> literal(in Label name, long value)
            => literal<long>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<float> literal(in Label name, float value)
            => literal<float>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<double> literal(in Label name, double value)
            => literal<double>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<decimal> literal(in Label name, decimal value)
            => literal<decimal>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<char> literal(in Label name, char value)
            => literal<char>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<string> literal(in Label name, string value)
            => literal<string>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static Literal<T> literal<T>(in Label name, Constant<T> value)
            => new Literal<T>(name, value);

        internal static Dictionary<string,TextVar> textvars(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = dict<string,TextVar>();
            var name = EmptyString;
            var parsing = false;
            for(var i=0; i<count-1; i++)
            {
                ref readonly var c0 = ref skip(src,i);
                ref readonly var c1 = ref skip(src,i+1);

                if(!parsing)
                {
                    if(c0 == Chars.Dollar && c1 == Chars.LParen)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c0 == Chars.RParen)
                    {
                        dst.TryAdd(name,new TextVar(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c0;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name,new TextVar(name));
            return dst;
        }
   }
}