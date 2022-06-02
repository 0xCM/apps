//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;
    using static TaggedLiterals;

    partial class Assets
    {
        [MethodImpl(Inline), Op]
        public static Index<ComponentAssets> assets(ReadOnlySpan<Assembly> src)
        {
            var dst = list<ComponentAssets>();
            iter(src, component => dst.Add(assets(component)));
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ComponentAssets assets(Assembly src, string match)
            => new ComponentAssets(src, collect(src, match));

        [MethodImpl(Inline), Op]
        public static ComponentAssets assets(Assembly src)
            => new ComponentAssets(src, collect(src));
    }
}