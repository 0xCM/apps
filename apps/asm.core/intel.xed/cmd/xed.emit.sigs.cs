//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/emit/sigs")]
        Outcome EmitInstSig(CmdArgs args)
        {
            const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
            var dst = text.emitter();
            InstSigs.render(InstSigs.sigs(Patterns), dst);
            AppSvc.FileEmit(dst.Emit(), Patterns.Count, XedPaths.InstTarget("patterns.sigs", FileKind.Csv));
            return true;
        }
    }
}