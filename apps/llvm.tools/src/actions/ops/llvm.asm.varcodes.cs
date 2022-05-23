//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using Asm;
    partial class LlvmCmdProvider
    {
        const string AsmVarCodeQuery = "llvm/asm/varcodes";

        [CmdOp(AsmVarCodeQuery)]
        void EmitVarCodes(CmdArgs args)
        {
            var src = DataProvider.AsmVariations();
            var dst = hashset<AsmVariationCode>();
            iter(src, v => dst.Add(v.Code));
            Query.EmitFile(AsmVarCodeQuery, @readonly(dst.Array().Sort()));
        }
    }
}

