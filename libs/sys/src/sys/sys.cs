//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct sys
    {
        const NumericKind Closure = Integers;

        const string EmptyString = "";

        internal const MethodImplOptions Options = MethodImplOptions.AggressiveInlining;
    }
}