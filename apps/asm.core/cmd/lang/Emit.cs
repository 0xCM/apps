//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        [CmdOp("lang/emit")]
        Outcome EmitCilOpCodes(CmdArgs args)
        {
            EmitCilOpCodes();
            return true;
        }

        void EmitCilOpCodes()
        {
            TableEmit(Cil.opcodes(), AppDb.Targets("lang").Path("cil.opcodes", FileKind.Csv));
        }
    }
}