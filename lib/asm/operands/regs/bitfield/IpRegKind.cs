//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static NativeSizeCode;
    using static RegFacets;
    using static RegClassCode;
    using static NumericBaseKind;

    /// <summary>
    /// Classifies instruction pointer registers
    /// </summary>
    [SymSource("asm.regs.bits", Base16)]
    public enum IpRegKind : ushort
    {
        IP = IPTR << ClassField | W16 << WidthField,

        EIP = IPTR << ClassField | W32 << WidthField,

        RIP = IPTR << ClassField | W64 << WidthField,
    }
}