//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class CodeGenProvider : AppCmdProvider<CodeGenProvider>
    {
        Generators Generators => Service(Wf.Generators);
    }
}