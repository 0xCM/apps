//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileFlows;

    public class AsmFlowCommands : AppService<AsmFlowCommands>
    {
        public SToAsmCmd Select(SToAsm flow)
            => Service(() => new SToAsmCmd());

        public AsmToMcAsmCmd Select(AsmToMcAsm flow)
            => Service(() => new AsmToMcAsmCmd());
    }
}