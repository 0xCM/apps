//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp("api/asm/csv")]
        Outcome AsmCsv(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = ApiPackArchive.HostAsmCsv().View;
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i));

            return result;
        }
    }
}