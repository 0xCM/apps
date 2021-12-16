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
        Outcome EmitVarCodes(CmdArgs args)
        {
            var src = DataProvider.SelectAsmVariations();
            var dst = hashset<AsmVariationCode>();
            iter(src, v => dst.Add(v.Code));
            var codes = dst.Array().Sort();
            DataEmitter.EmitQueryResults(AsmVarCodeQuery,@readonly(codes));
            return true;
        }
    }
}

