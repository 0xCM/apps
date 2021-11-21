//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;

    using Logic;

    using static Root;
    using static core;

    using XF = ExprPatterns;

    public readonly partial struct logic
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static Xor xor(IExpr a, IExpr b)
            => new Xor(a,b);

        [MethodImpl(Inline)]
        public static Not not(IVar a)
            => new Not(a);

        [MethodImpl(Inline), Op]
        public static Impl impl(IExpr @if, IExpr then)
            => new Impl(@if, then);

        [MethodImpl(Inline), Op]
        public static And and(IExpr a, IExpr b)
            => new And(a,b);

        [MethodImpl(Inline), Op]
        public static Or or(IExpr a, IExpr b)
            => new Or(a,b);

        [MethodImpl(Inline), Op]
        public Product<IExpr> product(params IExpr[] src)
            => new Product<IExpr>(src);

        [MethodImpl(Inline), Op]
        public Sum<IExpr> sum(params IExpr[] src)
            => new Sum<IExpr>(src);

        [MethodImpl(Inline)]
        public static Test<C> test<C>(C condition)
            where C : IExpr
                => new Test<C>(condition);

        /// <summary>
        /// Creates a binary union
        /// </summary>
        /// <param name="a">The first member</param>
        /// <param name="b">The second member</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Xor<T> xor<T>(T a, T b)
            => new Xor<T>(a,b);

        [MethodImpl(Inline)]
        public static Union untype<T>(Union<T> src)
            where T : IExpr
                => new Union(src.Terms.MapArray(x => (IExpr)x));

        internal static string format(in Except src)
        {
            var terms = src.Terms;
            var count = terms.Length;
            var dst = text.buffer();

            dst.Append(Chars.Tilde);
            dst.Append(XF.ListClose);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);

                dst.AppendFormat(RP.Slot0, skip(terms,i));

                if(i != count - 1)
                {
                    dst.Append(Chars.Space);
                    dst.Append(XF.Choice);
                }
            }
            dst.Append(XF.ListClose);
            return dst.Emit();
        }

        internal static string format<T>(in Xor<T> src)
            => string.Format(XF.BinaryChoice, src.Left, src.Right);

        internal static string format<C>(in Test<C> src)
            where C : IExpr
                => string.Format("?({0})", src.Condition);

        internal static string format<T>(in Product<T> src)
            where T : IExpr
        {
            const char Delimiter = (char)LogicSym.And;
            var dst = text.buffer();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref src[i];
                dst.Append(expr.Format());
                if(i != count - 1)
                    dst.Append(Delimiter);

            }
            return dst.Emit();
        }

        internal static string format<C>(in Sop<C> src)
            where C : IExpr
        {
            const char Delimiter = (char)LogicSym.Or;
            var dst = text.buffer();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var product = ref src[i];

                dst.Append(Chars.LParen);
                dst.Append(product.Format());
                dst.Append(Chars.RParen);

                if(i != count - 1)
                    dst.Append(Delimiter);
            }

            return dst.Emit();
        }

        internal static string format<T>(in Union<T> src)
            where T : IExpr
        {
            var dst = text.buffer();
            var terms = src.Terms;
            var count = terms.Length;
            dst.Append(XF.ListOpen);

            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);

                dst.AppendFormat(RP.Slot0, skip(terms,i));

                if(i != count - 1)
                {
                    dst.Append(Chars.Space);
                    dst.Append(XF.Choice);
                }
            }
            dst.Append(XF.ListClose);
            return dst.Emit();
        }

        internal static string format(in Union src)
        {
            var terms = src.Terms;
            var count = terms.Length;
            var dst = text.buffer();

            dst.Append(XF.ListOpen);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);

                dst.AppendFormat(RP.Slot0, skip(terms,i));

                if(i != count - 1)
                {
                    dst.Append(Chars.Space);
                    dst.Append(XF.Choice);
                }
            }
            dst.Append(XF.ListClose);

            return dst.Emit();
        }
    }
}