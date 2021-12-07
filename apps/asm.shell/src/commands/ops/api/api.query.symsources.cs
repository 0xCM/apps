//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp("api/query/symsources")]
        Outcome SymSources(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Clr.symsources(ApiRuntimeCatalog.Components).View;
            for(var i=0; i<src.Length; i++)
                Write(skip(src,i).Name);

            return result;
        }
    }
}