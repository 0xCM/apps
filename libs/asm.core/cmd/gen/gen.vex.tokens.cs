//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/vex/tokens")]
        Outcome GenTokenSpecs(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Symbols.concat(Symbols.index<AsmOcTokens.VexToken>());
            var name = "VexTokens";
            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            using var writer = dst.Writer();
            writer.WriteLine(string.Format("public readonly struct {0}", name));
            writer.WriteLine("{");
            CsLang.StringLits().Emit("Data", src, writer);
            writer.WriteLine("}");
            return result;
        }
    }
}