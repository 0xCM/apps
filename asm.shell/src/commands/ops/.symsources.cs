//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".components")]
        Outcome ApiComponents(CmdArgs args)
        {
            var src = ApiRuntimeLoader.assemblies();
            iter(src, c => c.Id());
            return true;
        }

        [CmdOp(".symsources")]
        Outcome SymSources(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Clr.symsources(ApiRuntimeLoader.assemblies()).View;
            for(var i=0; i<src.Length; i++)
                Write(skip(src,i).Name);

            return result;
        }
    }
}