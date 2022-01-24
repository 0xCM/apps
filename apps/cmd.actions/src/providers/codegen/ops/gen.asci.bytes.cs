//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CodeGenProvider
    {
        [CmdOp("gen/asci/bytes")]
        Outcome EmitAsciBytes(CmdArgs args)
        {
            var g = CodeGen.AsciLookups();
            var name = "Uppercase";
            var content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var dst = text.buffer();
            var bytes = g.Emit(8u, name,content, dst);
            Write(dst.Emit());
            return true;
        }
    }
}