//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    using System;

    partial class XTend
    {
        public static TypeSpec Spec(this Type src)
            => TypeSyntax.infer(src);
    }
}