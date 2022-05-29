//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("parsers/check")]
        void CheckParsers()
        {
            var count = Digital.parse("01001101", out GBlock64<BinaryDigit> dst);
            Write(Digital.format(slice(dst.Cells,0,count)));
        }
    }
}