//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct AsmStat : IComparable<AsmStat>
    {
        public const string TableId = "asm.stats";

        public AsmId Id;

        public uint Count;

        public int CompareTo(AsmStat src)
            => Id.ToString().CompareTo(src.Id.ToString());
    }
}