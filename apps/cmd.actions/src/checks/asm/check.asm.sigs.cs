//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/sigs")]
        Outcome CheckAsmSigs(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Symbols.index<AsmSigId>();
            var count = src.Count;
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref src[i];
                var expr = symbol.Expr.Format();
                result = AsmSigs.parse(expr, out var sig);
                if(result.Fail)
                    break;
            }

            return result;
        }
    }
}