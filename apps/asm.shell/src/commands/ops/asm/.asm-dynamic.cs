//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".asm-dynamic")]
        Outcome AsmExec(CmdArgs args)
        {
            CodeBuffer.Clear();
            var block = DFx.load(_Assembled, 0, CodeBuffer);
            //var _f = Marshal.GetDelegateForFunctionPointer<DelegateBindings.cpuid>(block.Address);
            var f = DFx.emitter<byte>(RoutineName, block);
            Write(string.Format("Evaluating: {0}[{1}]={2}", RoutineName, block.Size, RP.embrace(block.View.FormatHex())));
            // var f = DynamicOperations.binop<ulong>(RoutineName, block);
            var output = f.Operation.Invoke();
            Write(string.Format("Evaluated: {0}() -> {1}", f.Name, output));
            return true;
        }
    }
}