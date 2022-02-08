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

        X86Dispatcher JmpStubs => Service(() => X86Dispatcher.create(Wf));

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        Parsers Parsers => Service(Wf.Parsers);
    }
}