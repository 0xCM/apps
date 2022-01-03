//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-Extension-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum FieldType : byte
        {
            [Symbol("xed_bits_t")]
            Bits,

            [Symbol("xed_reg_enum_t")]
            Reg,

            [Symbol("xed_iclass_enum_t")]
            IClass,

            [Symbol("xed_chip_enum_t")]
            Chip,

            [Symbol("xed_uint8_t")]
            U8,

            [Symbol("xed_int8_t")]
            I8,

            [Symbol("xed_uint16_t")]
            U16,

            [Symbol("xed_int16_t")]
            I16,

            [Symbol("xed_uint32_t")]
            U32,

            [Symbol("xed_int32_t")]
            I32,

            [Symbol("xed_uint64_t")]
            U64,

            [Symbol("xed_int64_t")]
            I64,

            [Symbol("xed_error_enum_t")]
            Error,
        }
    }
}