//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [ApiHost, Free]
    public partial class math
    {
        const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;
    }
}