// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum ApiGridCategory : uint
    {
        None = 0,

        Generic = Pow2.T16,

        Natural = Pow2.T17,

        Fixed = Pow2.T18,

        Dynamic = Pow2.T19,

        Subgrid = Pow2.T20,

        Numeric = Pow2.T21,

        GenericDynamic = Generic | Dynamic,

        NaturalDynamic = Natural | Dynamic,

        FixedNatural = Fixed | Natural,

        FixedSubgrid = FixedNatural | Subgrid,

        NumericGeneric = Fixed | Numeric | Generic,
    }
}