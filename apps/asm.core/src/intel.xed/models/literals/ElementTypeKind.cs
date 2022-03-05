//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource("xed")]
        public enum ElementTypeKind
        {
            INVALID,

            [Symbol("UINT", "Unsigned integer")]
            UINT,

            [Symbol("INT", "Signed integer")]
            INT,

            [Symbol("SINGLE", "32b FP single precision")]
            SINGLE,

            [Symbol("DOUBLE", "64b FP single precision")]
            DOUBLE,

            [Symbol("LONGDOUBLE", "80b FP x87")]
            LONGDOUBLE,

            [Symbol("LONGBCD", "80b decimal BCD")]
            LONGBCD,

            [Symbol("STRUCT", "a structure of various fields")]
            STRUCT,

            [Symbol("VARIABLE", "depends on other fields in the instruction")]
            VARIABLE,

            [Symbol("FLOAT16", "16b floating point")]
            FLOAT16,

            [Symbol("BFLOAT16", "bfloat16 floating point")]
            BFLOAT16,
        }
    }
}