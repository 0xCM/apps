//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Workers)]

namespace Z0.Parts
{
    public sealed partial class Workers : Part<Workers>
    {

    }
}

namespace Z0
{
    using System;

    using static Root;

    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = UnsignedInts;
    }

    [ApiComplete]
    partial struct Msg
    {

    }
}