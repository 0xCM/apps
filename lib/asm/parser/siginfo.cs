//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmParser
    {
        [Parser]
        public static Outcome forminfo(string src, out AsmFormInfo dst)
        {
            dst = AsmFormInfo.Empty;
            var result = Outcome.Success;

            result = text.unfence(src, SigFence, out var sigexpr);
            if(result.Fail)
                return (false, AppMsg.FenceNotFound.Format(src,SigFence));

            result = siginfo(sigexpr, out var _sig);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format("Sig", sigexpr));

            result = text.unfence(src, OpCodeFence, out var opcode);
            if(result.Fail)
                return (false, AppMsg.FenceNotFound.Format(src,OpCodeFence));

            dst = new AsmFormInfo(new AsmOpCodeString(opcode), _sig);
            return true;
        }
    }
}