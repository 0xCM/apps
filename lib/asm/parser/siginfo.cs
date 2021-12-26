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
                return (false, FenceNotFound.Format(SigFence,src));

            result = siginfo(sigexpr, out var _sig);
            if(result.Fail)
                return (false, CouldNotParseSigExpr.Format(sigexpr));

            result = text.unfence(src, OpCodeFence, out var opcode);
            if(result.Fail)
                return (false, FenceNotFound.Format(OpCodeFence, src));

            dst = new AsmFormInfo(new AsmOpCodeString(opcode), _sig);
            return true;
        }

        public static MsgPattern<Fence<char>,string> FenceNotFound
            => "No content fenced with {0} exists int the input text '{1}'";

        public static MsgPattern<string> CouldNotParseSigExpr => "Could not created a signature expression from {0}";

        public static MsgPattern<Fence<char>> OpCodeFenceNotFound => "Op code fence {0} not found";
    }
}