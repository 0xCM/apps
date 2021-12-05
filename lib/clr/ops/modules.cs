//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrModuleAdapter> modules(Assembly src)
            => adapt(src.Modules());

        [MethodImpl(Inline), Op]
        public static ClrModuleAdapter manifest(Assembly src)
            => adapt(src.ManifestModule);
    }
}