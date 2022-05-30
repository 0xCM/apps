//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public void EmitTokens()
            => Emit(AsmTokens.Tokens);

        public void Emit(AsmTokens src)
            => AppSvc.TableEmit(src.View, SdmPaths.Tokens());
    }
}