//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmOpCodes
    {
        public static string expression(AsmOcToken src)
        {
            if(src.IsEmpty)
                return EmptyString;

            if(Datasets.TokenExpressions.Find(src.Id, out var x))
                return x;

            return RP.Error;
        }
    }
}