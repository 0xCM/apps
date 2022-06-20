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
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdService commands(IWfRuntime wf)
            => AppCmd.create(wf);

        public static void Main(params string[] args)
            => run(commands, args);
    }
}