//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static FileFlowSpecs;

    public class AsmFlowCommands : AppService<AsmFlowCommands>
    {
        public SToAsmCmd Select(SToAsm flow)
            => Service(() => SToAsmCmd.create(Wf));

        public AsmToMcAsmCmd Select(AsmToMcAsm flow)
            => Service(() => AsmToMcAsmCmd.create(Wf));
    }
}