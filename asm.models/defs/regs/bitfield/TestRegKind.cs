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

    public enum TestRegKind : ushort
    {
        TR0 = r0 | MASK << ClassField | W64 << WidthField,

        TR1 = r1 | MASK << ClassField | W64 << WidthField,

        TR2 = r2 | MASK << ClassField | W64 << WidthField,

        TR3 = r3 | MASK << ClassField | W64 << WidthField,

        TR4 = r4 | MASK << ClassField | W64 << WidthField,

        TR5 = r5 | MASK << ClassField | W64 << WidthField,

        TR6 = r6 | MASK << ClassField | W64 << WidthField,

        TR7 = r7 | MASK << ClassField | W64 << WidthField,
    }
}