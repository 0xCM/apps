//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Collections.Generic;
global using System.Collections.Concurrent;

global using static Z0.Root;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

[assembly: PartId(PartId.LlvmModels)]
namespace Z0.Parts
{
    public sealed partial class LlvmModels : Part<LlvmModels>
    {

    }
}

namespace Z0
{
    using llvm;

    [ApiHost]
    public static partial class XTend
    {

    }

    public static class XSvc
    {
    }
}