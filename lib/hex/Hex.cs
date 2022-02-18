//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Hex
    {
        const NumericKind Closure = UnsignedInts;
    }

    partial struct SymGroups
    {
        public const string hex = nameof(hex);
    }
}