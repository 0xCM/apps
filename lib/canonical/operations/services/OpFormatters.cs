//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using Logic;

    using static core;

    using XF = ExprPatterns;

    readonly struct OpFormatters
    {
        public static IFormatter<Except> Except()
            => default(ExceptFormatter);

        public static IFormatter<Union<T>> Union<T>()
            where T : IExpr
                => default(UnionFormatter<T>);

        public static IFormatter<Union> Union()
            => default(UnionFormatter);

        public static IFormatter<Product> Product()
            => default(ProductFormatter);

        public static IFormatter<Product<T>> Product<T>()
            where T : IExpr
                => default(ProductFormatter<T>);

        public static IFormatter<Sop<T>> Sop<T>()
            where T : IExpr
                => default(SopFormatter<T>);

        public static IFormatter<Xor<T>> Xor<T>()
            => default(XorFormatter<T>);

        readonly struct XorFormatter<T> : IFormatter<Xor<T>>
        {
            public string Format(Xor<T> src)
                => string.Format(XF.BinaryChoice, src.Left, src.Right);
        }

        readonly struct SopFormatter<T> : IFormatter<Sop<T>>
            where T : IExpr
        {
            public string Format(Sop<T> src)
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
        }

        readonly struct ProductFormatter<T> : IFormatter<Product<T>>
            where T : IExpr
        {
            public string Format(Product<T> src)
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
        }

        readonly struct ProductFormatter : IFormatter<Product>
        {
            public string Format(Product src)
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
        }

        readonly struct UnionFormatter : IFormatter<Union>
        {
            public string Format(Union src)
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

        readonly struct UnionFormatter<T> : IFormatter<Union<T>>
            where T : IExpr
        {
            public string Format(Union<T> src)
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
        }

        [Formatter(typeof(Except))]
        readonly struct ExceptFormatter : IFormatter<Except>
        {
            public string Format(Except src)
            {
                var terms = src.Terms.Array();
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
        }
    }
}