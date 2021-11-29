//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Expr;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(".emit-asm-names")]
        Outcome EmitAsmNames(CmdArgs args)
        {
            var src = TableLoader.LoadVariations().Where(x => x.Mnemonic.IsNonEmpty).Map(x => x.Mnemonic.Format()).Distinct().Sort();
            using var literals = expr.literals(src.View,src.View);
            var gen = Wf.Generators();
            var dst = Ws.Project("gen").Subdir("llvm") + FS.file("AsmNames", FS.Cs);
            gen.GenLiteralProvider("Z0.llvm", "AsmNames", literals.Literals, dst);

            return true;
        }
    }
}