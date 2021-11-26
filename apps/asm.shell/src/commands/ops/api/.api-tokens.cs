//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".emit-api-tokens")]
        Outcome EmitTokens(CmdArgs args)
        {
            Wf.ApiMetadata().EmitApiTokens();
            return true;
        }

        [CmdOp(".emit-asm-tokens")]
        Outcome EmitAsmTokens(CmdArgs args)
        {
            var tokens = Wf.AsmTokens();
            var project = Ws.Project("db");
            var svc = Wf.ApiMetadata();
            var scope = "api";
            svc.EmitTokens(tokens.RegTokens(), project, scope);
            svc.EmitTokens(tokens.OpCodeTokens(), project, scope);
            svc.EmitTokens(tokens.SigTokens(), project, scope);
            svc.EmitTokens(tokens.ConditonTokens(), project, scope);
            svc.EmitTokens(tokens.PrefixTokens(), project, scope);
            return true;
        }
    }
}