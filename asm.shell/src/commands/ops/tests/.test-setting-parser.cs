//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".test-setting-parser")]
        Outcome TestSettingParser(CmdArgs args)
        {
            var result = Outcome.Success;
            var a = "A:603";
            DataParser.parse(a, out Setting<ushort> _a);
            Write(_a);


            var b = "B:true";
            DataParser.parse(b, out Setting<bool> _b);
            Write(_b);
            return result;
        }
    }
}