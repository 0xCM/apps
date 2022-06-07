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

[assembly: PartId(PartId.Commands)]

namespace Z0.Parts
{
    public sealed partial class Commands : Part<Commands>
    {

    }
}

namespace Z0
{
    struct Msg
    {
        public static MsgPattern<FS.FileUri,TextEncodingKind,Count> SplittingFile
            => "Splitting {0} into {1}-encoded parts with a maximum of {2} lines each";

        public static MsgPattern<Count,FS.FileUri,Count> FinishedFileSplit
            => "Partitioned {0} lines from {1} into {2} parts";

    }
}
