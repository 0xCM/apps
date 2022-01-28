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

        SdmSigOpRules SdmRules => Service(Wf.SdmRules);

        IntelSdmPaths SdmPaths => Service(Wf.SdmPaths);
    }
}