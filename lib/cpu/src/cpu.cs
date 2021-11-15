//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    [ApiHost]
    public readonly partial struct cpu
    {
        const string inflate = ApiGroupNames.inflate;

        const NumericKind Closure = UnsignedInts;
    }

    [ApiHost]
    public readonly partial struct gcpu
    {
        const string inflate = ApiGroupNames.inflate;

        const NumericKind Closure = UnsignedInts;
    }
}