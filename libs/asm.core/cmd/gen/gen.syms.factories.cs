//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("gen/syms/factories")]
        Outcome GenSymFactories(CmdArgs args)
        {
            var name = "AsmRegTokens";
            var dst = AppDb.CgStage().Path(name, FileKind.Cs);
            var src = typeof(AsmRegTokens).GetNestedTypes().Where(x => x.Tagged<SymSourceAttribute>());
            CsLang.GenSymFactories("Z0.Asm", name, src, dst);
            return true;
        }
    }
}