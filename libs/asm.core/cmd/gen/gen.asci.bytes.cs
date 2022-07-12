//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/asci/bytes")]
        Outcome EmitAsciBytes(CmdArgs args)
        {
            var name = "Uppercase";
            var content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var dst = text.buffer();
            var bytes = CsLang.AsciLookups().Emit(8u, name,content, dst);
            Write(dst.Emit());
            return true;
        }
    }
}