// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Defines grid-sort datatype classifiers
    /// </summary>
    [Flags]
    public enum ApiGridKind : uint
    {
        None = 0,

        Generic = ApiGridCategory.Generic,

        Natural = ApiGridCategory.Natural,

        Fixed = ApiGridCategory.Fixed,

        Unfixed = ApiGridCategory.Dynamic,

        Subgrid = ApiGridCategory.Subgrid,

        Numeric = ApiGridCategory.Numeric,

        GenericUnfixed = ApiGridCategory.GenericDynamic,

        NaturalUnfixed = ApiGridCategory.NaturalDynamic,

        FixedNatural = ApiGridCategory.FixedNatural,

        FixedSubgrid = ApiGridCategory.FixedSubgrid,

        NumericGeneric = ApiGridCategory.NumericGeneric,

        Numeric16 = 16 | NumericGeneric,

        Numeric32 = 32 | NumericGeneric,

        Numeric64 = 64 | NumericGeneric,

        Natural16 = 16 | FixedNatural,

        Natural32 = 32 | FixedNatural,

        Natural64 = 64 | FixedNatural,

        Natural128 = 128 | FixedNatural,

        Natural256 = 256 | FixedNatural,

        Subgrid16 = 16 | FixedSubgrid,

        Subgrid32 = 32 | FixedSubgrid,

        Subgrid64 = 64 | FixedSubgrid,

        Subgrid128 = 128 | FixedSubgrid,

        Subgrid256 = 256 | FixedSubgrid,
    }
}