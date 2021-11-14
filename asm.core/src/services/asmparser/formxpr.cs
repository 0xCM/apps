//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmParser
    {
        [Op]
        public static Outcome formxpr(string src, out AsmFormInfo dst)
        {
            dst = AsmFormInfo.Empty;
            var result = Outcome.Success;

            result = text.unfence(src, SigFence, out var sigexpr);
            if(result.Fail)
                return (false, FenceNotFound.Format(SigFence,src));

            result = sigxpr(sigexpr, out var _sig);
            if(result.Fail)
                return (false, Msg.CouldNotParseSigExpr.Format(sigexpr));

            result = text.unfence(src, OpCodeFence, out var opcode);
            if(result.Fail)
                return (false, FenceNotFound.Format(OpCodeFence, src));

            dst = new AsmFormInfo(asm.ocstring(opcode), _sig);
            return true;
        }

        public static MsgPattern<Fence<char>,string> FenceNotFound
            => "No content fenced with {0} exists int the input text '{1}'";
    }
}