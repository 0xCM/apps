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

    partial struct Resources
    {
        [Op]
        public static string[] names(Assembly src, string match)
            => minicore.nonempty(match) ? src.ManifestResourceNames().Where(n => n.Contains(match)) : src.ManifestResourceNames();

        [MethodImpl(Inline), Op]
        public static string[] names(Assembly src)
            => src.GetManifestResourceNames();
    }
}