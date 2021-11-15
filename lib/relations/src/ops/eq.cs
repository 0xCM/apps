//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct relations
    {
        [MethodImpl(Inline), Op]
        public static bool eq(ArrowType a, ArrowType b)
            => a.Source == b.Source && a.Target == b.Target;

        [Op]
        public static uint hash32(ArrowType src)
            => alg.hash.calc(src.Source) ^ alg.hash.calc(src.Target) ^ alg.hash.calc(src.Kind);
    }
}