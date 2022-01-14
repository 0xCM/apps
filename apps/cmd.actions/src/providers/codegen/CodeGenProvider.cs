//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Root;
    using static core;

    public partial class CodeGenProvider : AppCmdProvider<CodeGenProvider>
    {
        Generators Generators => Service(Wf.Generators);

        IntelSdm Sdm => Service(Wf.IntelSdm);
    }
}