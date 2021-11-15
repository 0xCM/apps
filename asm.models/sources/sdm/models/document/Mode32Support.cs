//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [SymSource]
        public enum Mode32Support : byte
        {
            None,

            [Symbol("V", "Supported")]
            V,

            [Symbol("I", "Not Supported")]
            I,

            [Symbol("N.E.", "Not Encodable; the opbode sequence is not applicable as n individual instruction in compatiblity or IA-32 mode")]
            NE,
        }
    }
}