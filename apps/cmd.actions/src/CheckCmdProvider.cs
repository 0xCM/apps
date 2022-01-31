//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class CheckCmdProvider : AppCmdProvider<CheckCmdProvider>
    {
        IntelSdm Sdm => Service(Wf.IntelSdm);

        JmpStubs JmpStubs => Service(() => JmpStubs.create(Wf));

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);
    }
}