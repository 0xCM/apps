//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading.Tasks;

global using static Z0.Root;
global using SQ = Z0.SymbolicQuery;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

[assembly: PartId(PartId.AsmServices)]

namespace Z0.Parts
{
    public sealed partial class AsmServices : Part<AsmServices>
    {

    }
}

namespace Z0
{
    public static partial class XTend
    {
        public static AsmCmdProvider AsmCommands(this IWfRuntime wf)
            => AsmCmdProvider.create(wf);

        public static AsmFlowCommands AsmFlowCommands(this IWfRuntime wf)
            => Z0.AsmFlowCommands.create(wf);
        [Op]
        public static ProjectDataServices ProjectData(this IWfRuntime wf)
            => Z0.ProjectDataServices.create(wf);
    }
}