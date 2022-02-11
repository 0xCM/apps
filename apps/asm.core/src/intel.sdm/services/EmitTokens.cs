//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public void EmitTokens()
        {
            var tokens = AsmTokens.load();
            TableEmit(tokens.View, AsmToken.RenderWidths, SdmPaths.Tokens());
        }
    }
}