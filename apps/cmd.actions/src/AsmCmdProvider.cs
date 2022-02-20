//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public sealed partial class AsmCmdProvider : AppCmdProvider<AsmCmdProvider>
    {
        AsmRegSets RegSets => Service(AsmRegSets.create);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        AsmGen AsmGen => Service(AsmGen.generator);
    }
}