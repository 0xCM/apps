// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum FixedSubGridKind : uint
    {
        None = 0,

        FSG16 = 16 | ApiGridCategory.FixedSubgrid,

        FSG32 = 32 | ApiGridCategory.FixedSubgrid,

        FSG64 = 64 | ApiGridCategory.FixedSubgrid,

        FSG128 = 128 | ApiGridCategory.FixedSubgrid,

        FSG256 = 256 | ApiGridCategory.FixedSubgrid,
    }
}