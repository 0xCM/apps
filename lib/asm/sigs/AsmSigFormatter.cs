//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class AsmSigFormatter
    {
        AsmSigDatasets Datasets;

        public AsmSigFormatter()
        {
            Datasets = AsmSigDatasets.load();
        }

        public static string format(in AsmSig src)
        {
            var dst = text.buffer();
            var count = src.OpCount;
            for(byte i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Comma);
                dst.Append(expression(src[i]));
            }
            return dst.Emit();
        }

        public string Format(in AsmSig src)
        {
            var dst = text.buffer();
            var count = src.OpCount;
            for(byte i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Comma);
                dst.Append(Expression(src[i]));
            }
            return dst.Emit();
        }

        string Expression(AsmSigOp src)
            => Datasets.TokenExpressions[src];

        static string expression(AsmSigOp src)
            => _Datasets.TokenExpressions[src];

        static AsmSigFormatter()
        {
            _Datasets = AsmSigDatasets.load();
        }

        static AsmSigDatasets _Datasets;
    }
}