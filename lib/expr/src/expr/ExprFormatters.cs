//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    readonly struct ExprFormatters
    {
        public static ITextFormatter<LiteralSeq<T>> LiteralSeq<T>()
            => default(LiteralSeqFormatter<T>);

        readonly struct LiteralSeqFormatter<T> : ITextFormatter<LiteralSeq<T>>
        {
            public string Format(LiteralSeq<T> src)
            {
                var dst = text.buffer();
                var w = core.width<T>();
                var count = src.Count;
                var margin = 0u;
                dst.AppendFormat("literals<uint{0}> {1} = {{", w, src.Name);
                margin +=4;
                for(var i=0; i<count; i++)
                {
                    ref readonly var term = ref src[i];
                    dst.IndentLineFormat(margin, "{0} = {1},", term.Name, term.Value);
                }
                margin -=4;
                dst.IndentLine(margin, "}");
                return dst.Emit();

            }
        }
    }
}
