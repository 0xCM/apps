//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum AllocationKind : byte
    {
        Label,

        String,

        Memory,

        Page,

        Source,

        Symbol,

        NativeSig,

        Composite,
    }
}