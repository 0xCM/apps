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

[assembly: PartId(PartId.IntelIntrinsics)]

namespace Z0.Parts
{
    public sealed class IntelIntrinsics : Part<IntelIntrinsics>
    {
        public static PartAssets AssetData = new();

        public sealed class PartAssets : Assets<PartAssets>
        {
            public Asset Csv() => Asset("intrinsics.csv");

            public Asset Algorithms() => Asset("intrinsics.algorithms.txt");
        }
    }
}