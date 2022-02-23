//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    partial class CodeGenProvider
    {
        [CmdOp("gen/sym-factories")]
        Outcome GenSymFactories(CmdArgs args)
        {
            var name = "AsmRegTokens";
            var dst = ProjectDb.Subdir("logs") + FS.file("regtokens", FS.Cs);
            var src = typeof(AsmRegTokens).GetNestedTypes().Where(x => x.Tagged<SymSourceAttribute>());
            Wf.CodeGen().GenSymFactories("Z0.Asm", name, src, dst);
            return true;
        }
    }
}