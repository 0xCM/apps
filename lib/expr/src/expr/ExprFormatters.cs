//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using XF = ExprPatterns;

    readonly struct ExprFormatters
    {
        public static ITextFormatter<SeqRange<T>> SeqRange<T>()
            => default(SeqRangeFormatter<T>);

        public static ITextFormatter<LiteralSeq<T>> LiteralSeq<T>()
            => default(LiteralSeqFormatter<T>);

        readonly struct SeqRangeFormatter<T> : ITextFormatter<SeqRange<T>>
        {
            public string Format(SeqRange<T> src)
                => string.Format(XF.InclusiveRange, src.Min, src.Max);
        }

        readonly struct LiteralSeqFormatter<T> : ITextFormatter<LiteralSeq<T>>
        {
            public string Format(LiteralSeq<T> src)
            {
                var dst = text.buffer();
                var w = core.width<T>();
                var count = src.Count;
                var margin = 0u;
                dst.AppendLineFormat("{1}:seq<uint{0}> = {{", w, src.Name);
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
