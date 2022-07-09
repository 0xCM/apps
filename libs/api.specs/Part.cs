//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Diagnostics;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading;
global using System.Threading.Tasks;
global using System.IO;

global using static Z0.Root;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;
[assembly: PartId(PartId.ApiSpecs)]
namespace Z0.Parts
{
    public sealed class ApiSpecs : Part<ApiSpecs>
    {
    }
}

namespace Z0
{
    public static partial class XTend
    {

    }
}

namespace Z0
{
    public static class XSvc
    {
        sealed class AppSvcCache : AppServices<AppSvcCache>
        {
            public BdDisasm BdDisasm(IWfRuntime wf)
                => Service<BdDisasm>(wf);


            public DumpBin DumpBin(IWfRuntime wf)
                => Service<DumpBin>(wf);


            public AsmFlowCommands AsmFlows(IWfRuntime wf)
                => Service<AsmFlowCommands>(wf);


            public XedTool XedTool(IWfRuntime wf)
                => Service<XedTool>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public Nasm Nasm(IWfRuntime wf)
                => Service<Nasm>(wf);

            public NDisasm NDisasm(IWfRuntime wf)
                => Service<NDisasm>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);
        }


       static AppSvcCache Services => AppSvcCache.Instance;

       public static AsmFlowCommands AsmFlows(this IWfRuntime wf)
            => Services.AsmFlows(wf);


        public static BdDisasm BdDisasm(this IWfRuntime wf)
            => Services.BdDisasm(wf);

        public static XedTool XedTool(this IWfRuntime wf)
            => Services.XedTool(wf);


        public static DumpBin DumpBin(this IWfRuntime wf)
            => Services.DumpBin(wf);


        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Services.NasmCatalog(wf);

        public static Nasm Nasm(this IWfRuntime wf)
            => Services.Nasm(wf);

        public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Services.CultProcessor(wf);

        public static NDisasm NDisasm(this IWfRuntime wf)
            => Services.NDisasm(wf);


    }
}