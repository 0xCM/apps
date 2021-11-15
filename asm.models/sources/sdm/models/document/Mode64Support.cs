//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [SymSource]
        public enum Mode64Support : byte
        {
            None,

            [Symbol("V", "Supported")]
            V,

            [Symbol("I", "Not Supported")]
            I,

            [Symbol("N.E.", "Indicates an instruction syntax is not encodable in 64-bit mode")]
            NE,

            [Symbol("N.P.", "Indicates the REX prefix does not affect the legacy instruction in 64-bit mode")]
            NP,

            [Symbol("N.I.", "Indicates the opcode is treated as a new instruction in 64-bit mode")]
            NI,

            [Symbol("N.S.", "Indicates an instruction syntax that requires an address override prefix in 64-bit mode and is not suported")]
            NS
        }
    }
}