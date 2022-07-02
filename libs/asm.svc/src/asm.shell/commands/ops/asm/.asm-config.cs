//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".asm-config")]
        Outcome AsmConfig(CmdArgs args)
        {
            var result = OmniScript.Run(AsmWs.Script("log-config"), out var response);
            if(result.Fail)
                return result;

            var src = Settings.parse(response);
            var count = src.Length;
            var vars = new CmdVar[count];
            for(var i=0; i<count; i++)
            {
                ref readonly var facet = ref src[i];
                seek(vars,i) = CmdScripts.var(facet.Name, facet.Value);
            }

            iter(vars, v => Write(v.Name,
                v.Evaluated ? string.Format("{0} (Evaluated)", v.Value) : string.Format("{0} (Symbolic)", v.Value))
                );

            return result;
        }
    }
}