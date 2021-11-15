//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// datafiles/xed-operand-element-type-enum-base.txt
        /// </summary>
        [SymSource(xed)]
        public enum OperandTypeKind : byte
        {
            /// <summary>
            /// Unspecified/unknown
            /// </summary>
            INVALID,

            /// <summary>
            /// Unsigned integer
            /// </summary>
            [Symbol("UINT","Unsigned integer")]
            UINT,

            /// <summary>
            /// Signed integer
            /// </summary>
            [Symbol("INT","Signed integer")]
            INT,

            /// <summary>
            /// 32b FP single precision
            /// </summary>
            [Symbol("SINGLE","32b FP single precision")]
            SINGLE,

            /// <summary>
            /// 64b FP double precision
            /// </summary>
            [Symbol("DOUBLE","64b FP double precision")]
            DOUBLE,

            /// <summary>
            /// 80b FP x87
            /// </summary>
            [Symbol("LONGDOUBLE","80b FP x87")]
            LONGDOUBLE,

            /// <summary>
            /// 80b decimal BCD
            /// </summary>
            [Symbol("LONGBCD","80b decimal BCD")]
            LONGBCD,

            /// <summary>
            /// a structure of various fields
            /// </summary>
            [Symbol("STRUCT","a structure of various fields")]
            STRUCT,

            /// <summary>
            /// depends on other fields in the instruction
            /// </summary>
            [Symbol("VARIABLE","depends on other fields in the instruction")]
            VARIABLE,
        }
    }
}