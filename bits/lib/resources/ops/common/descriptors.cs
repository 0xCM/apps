//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Resources
    {
        [MethodImpl(Inline), Op]
        public static Index<ComponentAssets> descriptors(ReadOnlySpan<Assembly> src)
        {
            var dst = list<ComponentAssets>();
            iter(src, component => dst.Add(descriptors(component)));
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ComponentAssets descriptors(Assembly src, string match)
            => new ComponentAssets(src, collect(src, match));

        [MethodImpl(Inline), Op]
        public static ComponentAssets descriptors(Assembly src)
            => ComponentAssets.from(src);
    }
}