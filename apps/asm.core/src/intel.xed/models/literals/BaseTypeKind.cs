//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        [SymSource(xed)]
        public enum BaseTypeKind
        {
            INVALID,

            B80,

            BF16,

            F16,

            F32,

            F64,

            F80,

            I1,

            I16,

            I32,

            I64,

            I8,

            INT,

            STRUCT,

            U128,

            U16,

            U256,

            U32,

            U64,

            U8,

            UINT,

            VAR,
        }
    }
}