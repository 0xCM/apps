//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/vectors")]
        Outcome EmitOpVectors(CmdArgs args)
        {
            const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
            var src = XedRules.vectors(Patterns);
            var dst = text.emitter();
            dst.AppendLineFormat(RenderPattern, "Instruction", "Lock", "OpCode", "Vector");
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i].Left;
                ref readonly var vector = ref src[i].Right;
                dst.AppendLineFormat(RenderPattern, classifier(pattern.InstClass), pattern.Lock, pattern.OpCode, vector);
            }

            AppSvc.FileEmit(dst.Emit(), src.Count, XedPaths.InstTarget("ops.vectors", FileKind.Csv));
            return true;
        }
    }
}