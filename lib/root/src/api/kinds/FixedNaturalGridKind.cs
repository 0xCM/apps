// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum FixedNaturalGridKind : uint
    {
        None = 0,

        FN16 = 16 | ApiGridCategory.FixedNatural,

        FN32 = 32 | ApiGridCategory.FixedNatural,

        FN64 = 64 | ApiGridCategory.FixedNatural,

        FN128 = 128 | ApiGridCategory.FixedNatural,

        FN256 = 256 | ApiGridCategory.FixedNatural,
    }
}