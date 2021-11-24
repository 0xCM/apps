//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public readonly struct types
    {
        const NumericKind Closure = UnsignedInts;

        internal static string format(PrimalKind src)
            => src.ToString().ToLower();

        internal static Outcome parse(char src, out PrimalKind dst)
        {
            var symbols = Symbols.index<PrimalKind>();
            dst = default;
            return false;
        }
    }
}