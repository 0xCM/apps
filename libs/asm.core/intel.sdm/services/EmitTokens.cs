//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public void EmitTokens()
        {
            TableEmit(AsmTokens.OcTokenDefs.View, SdmPaths.Tokens("sdm.tokens.opcodes"), unicode);
            TableEmit(AsmTokens.SigTokenDefs.View, SdmPaths.Tokens("sdm.tokens.sigs"), unicode);
            TableEmit(AsmTokens.TokenDefs.View, SdmPaths.Tokens("sdm.tokens"), unicode);
        }
    }
}