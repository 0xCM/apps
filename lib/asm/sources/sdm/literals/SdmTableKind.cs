//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public enum SdmTableKind : byte
        {
            None = 0,

            [Symbol("OpCodes")]
            OpCodes,

            [Symbol("Encoding")]
            EncodingRule,

            [Symbol("BinaryFormat")]
            BinaryFormat,

            [Symbol("Intrinsics")]
            Intrinsics,

            [Symbol("Notes")]
            Notes,

            [Symbol("Numbered")]
            Numbered,
        }
    }
}