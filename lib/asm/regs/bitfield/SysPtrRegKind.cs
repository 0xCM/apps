//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegFieldFacets;
    using static RegIndexCode;
    using static RegClassCode;
    using static NativeSizeCode;

    public enum SysPtrRegKind : ushort
    {
        GDTR = r0 | SPTR << ClassField | W64 << WidthField,

        LDTR = r1 | SPTR << ClassField | W64 << WidthField,

        IDTR = r2 | SPTR << ClassField | W64 << WidthField,
    }
}