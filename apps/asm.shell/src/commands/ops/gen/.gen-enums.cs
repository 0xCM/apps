//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".gen-enums")]
        Outcome GenEnums(CmdArgs args)
        {
            var result = Outcome.Success;
            var svc = Wf.Generators().CsEnum();
            var spec = Symbols.set(typeof(AsmOpCodeTokens.VexToken));
            var type = spec.DataType;
            var buffer = text.buffer();
            svc.Generate(0,spec,buffer);
            Write(buffer.Emit());
            return result;
        }
    }
}