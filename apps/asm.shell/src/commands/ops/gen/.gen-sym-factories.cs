//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".gen-sym-factories")]
        Outcome GenSymFactories(CmdArgs args)
        {
            var dst = Ws.Gen().Path("regcodes", FS.Cs);
            var src = typeof(AsmRegTokens).GetNestedTypes().Where(x => x.Tagged<SymSourceAttribute>());
            Wf.Generators().GenSymFactories("Z0.Asm", "AsmRegNames", src, dst);
            return true;
        }
    }
}