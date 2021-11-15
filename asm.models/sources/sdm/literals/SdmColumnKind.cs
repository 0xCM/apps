//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [SymSource]
        public enum SdmColumnKind : byte
        {
            None = 0,

            OpCode,

            Signature,

            EncodingRef,

            Cpuid,

            Mode64,

            Mode32,

            Mode64x32,

            Description,

            Op1,

            Op2,

            Op3,

            Op4
        }
    }
}