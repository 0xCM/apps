//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource]
    public enum AsmAddressing : byte
    {
        None = 0,

        /// <summary>
        /// Indicates the value is encoded in the instruction
        /// </summary>
        Imm,

        /// <summary>
        /// Indicates source and target values are within registers
        /// </summary>
        Register,

        /// <summary>
        /// Indicates a source or target value is of the form base + index*scale + disp
        /// where 'base' and 'index' denote registers of common width
        /// </summary>
        Indirect,

        /// <summary>
        /// Indicates a value encodes an instruction address relative to the start address
        /// of the next instruction
        /// </summary>
        RipRelative
    }
}