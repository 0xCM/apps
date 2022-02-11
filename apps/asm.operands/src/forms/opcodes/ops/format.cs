//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmOpCodes
    {
        public static string format(AsmOcToken src)
            => Datasets.TokenExpressions[src];

        public static string format(in AsmOpCode src)
        {
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
                dst.Append(expression(src[i]));
            return dst.Emit();
        }
    }
}