//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static NativeSizeCode;
    using static RegFieldFacets;
    using static RegClassCode;

    /// <summary>
    /// Classifies instruction pointer registers
    /// </summary>
    public enum IpRegKind : ushort
    {
        IP = IPTR << ClassField | W16 << WidthField,

        EIP = IPTR << ClassField | W32 << WidthField,

        RIP = IPTR << ClassField | W64 << WidthField,
    }
}