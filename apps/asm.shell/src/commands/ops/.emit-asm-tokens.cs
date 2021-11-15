//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class AsmCmdService
    {
        Outcome EmitTokenSpecs(CmdArgs args)
        {
            var result = Outcome.Success;

            var svc = Wf.Symbolism();
            var output = svc.EmitTokenSpecs(typeof(AsmOpCodeTokens.VexToken));
            var input = svc.LoadTokenSpecs(nameof(AsmOpCodeTokens.VexToken));
            var formatter = Tables.formatter<SymInfo>(SymInfo.RenderWidths);
            var count = input.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(input,i);
                Write(formatter.Format(row));
            }

            return result;
        }

        [CmdOp(".emit-asm-tokens")]
        Outcome EmitAsmTokens(CmdArgs args)
        {
            var tokens = Wf.AsmTokens();
            EmitTokens(tokens.RegTokens());
            EmitTokens(tokens.OpCodeTokens());
            EmitTokens(tokens.SigTokens());
            EmitTokens(tokens.ConditonTokens());
            EmitTokens(tokens.PrefixTokens());
            return true;
        }
    }
}