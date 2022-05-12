//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/check/forms")]
        Outcome CheckFormImports(CmdArgs args)
        {
            // const string RowFormat = "{0,-12} | {1,-24} | {2}";
            // var map = Xed.Views.ChipMap;
            // var dst = text.emitter();
            // var counter = 0u;
            // dst.WriteLine(string.Format(RowFormat, "Sequence", "ChipCode", "Isa"));
            // var codes = map.Codes;
            // foreach(var code in codes)
            // {
            //     var mapped = map[code];
            //     foreach(var kind in mapped)
            //         dst.WriteLine(string.Format(RowFormat, counter++ , code, kind));
            // }
            // AppSvc.FileEmit(dst.Emit(),counter,XedPaths.ChipMapTarget());
            return true;
        }

        [CmdOp("xed/emit/sigs")]
        Outcome EmitInstSig(CmdArgs args)
        {
            const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
            var dst = text.emitter();
            InstSigs.render(InstSigs.sigs(Patterns),dst);
            AppSvc.FileEmit(dst.Emit(), Patterns.Count, XedPaths.InstTarget("patterns.sigs", FileKind.Csv));
            return true;
        }
    }
}