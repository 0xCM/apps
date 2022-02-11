//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmOpCodes
    {
        public static string expression(AsmOcToken src)
            => Datasets.TokenExpressions[src];
    }
}