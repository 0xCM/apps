//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class CodeGenProvider : AppCmdProvider<CodeGenProvider>
    {
        AppDb AppDb => Service(Wf.AppDb);

        CgSvc CodeGen => Service(Wf.CodeGen);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        IntelXed Xed => Service(Wf.IntelXed);
    }
}