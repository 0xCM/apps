//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static bool IsPart(this Assembly src)
            => Attribute.IsDefined(src, typeof(PartIdAttribute));
    }
}