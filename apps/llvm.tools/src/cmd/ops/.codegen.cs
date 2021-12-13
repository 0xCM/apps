//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {

        [CmdOp(".gen-enums")]
        Outcome GenEnums(CmdArgs args)
        {
            var result = Outcome.Success;
            var svc = Wf.Generators().CsEnum();
            var spec = Symbols.set(typeof(clang.index.SymbolSubKind));
            var type = spec.DataType;
            var buffer = text.buffer();
            svc.Generate(0,spec,buffer);
            Write(buffer.Emit());
            return result;
        }
    }
}