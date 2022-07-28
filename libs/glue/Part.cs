//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System.Collections.Immutable;
global using System.Reflection;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading.Tasks;
global using System.Globalization;
global using System.Threading;
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.Emit;
global using Microsoft.DiaSymReader;
global using System.Diagnostics;
global using static Z0.Root;
[assembly: PartId(PartId.Glue)]

namespace Z0.Parts
{
    public sealed class Glue : Part<Glue>
    {
        public static PartAssets Assets = new PartAssets();

        public sealed class PartAssets : Assets<PartAssets>
        {

        }
    }
}