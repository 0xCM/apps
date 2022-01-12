//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Root
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    [ApiHost]
    public static partial class XText
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    [ApiHost]
    public static partial class ClrQuery
    {
        const NumericKind Closure = Root.UnsignedInts;
    }
}