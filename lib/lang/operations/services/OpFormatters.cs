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
        [Formatter]
        public static string format(Sum src)
        {
            var terms = src.Members;
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


        [Formatter]
        public static string format(Product src)
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

        public static string format<T>(Xor<T> src)
            => string.Format(XF.BinaryChoice, src.Left, src.Right);

        public static string format<T>(Product<T> src)
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

        public static string format<T>(Sop<T> src)
            where T : IExpr
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

        [Formatter]
        public static string format(Except src)
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