//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Flags]
    public enum AsmPrefixGroup : byte
    {
        None,

        Group1 = 1,

        Group2 = 2,

        Group3 = 4,

        Group4 = 8,
    }
}