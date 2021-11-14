//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".opcodes")]
        Outcome EmitOpCodes(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = llvm.MC.opcodes().View;
            var dst = LlvmData.TablePath<OpCodeSpec>();
            TableEmit(src, OpCodeSpec.RenderWidths, dst);
            return result;
        }
    }
}