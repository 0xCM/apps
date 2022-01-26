//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmOcFormatter
    {
        AsmOcDatasets Datasets;

        public AsmOcFormatter()
        {
            Datasets = AsmOcDatasets.load();
        }

        public static string format(in AsmOpCode src)
        {
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(expression(src[i]));
            }
            return dst.Emit();
        }

        public string Format(in AsmOpCode src)
        {
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(Expression(src[i]));
            }
            return dst.Emit();
        }

        string Expression(AsmOcToken src)
            => Datasets.TokenExpressions[src];

        static string expression(AsmOcToken src)
            => _Datasets.TokenExpressions[src];

        static AsmOcFormatter()
        {
            _Datasets = AsmOcDatasets.load();
        }

        static AsmOcDatasets _Datasets;
    }
}
