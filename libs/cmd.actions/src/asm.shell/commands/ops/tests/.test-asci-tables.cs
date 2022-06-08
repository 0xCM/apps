//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-asci-tables")]
        Outcome TestAsciTables(CmdArgs args)
        {
            var result = Outcome.Success;
            var buffer = span<char>(128);
            Write(text.format(AsciTables.letters(LowerCase).Codes, buffer));
            buffer.Clear();
            Write(text.format(AsciTables.letters(UpperCase).Codes, buffer));
            buffer.Clear();
            Write(text.format(AsciTables.digits().Codes, buffer));
            buffer.Clear();
            return result;
        }
    }
}