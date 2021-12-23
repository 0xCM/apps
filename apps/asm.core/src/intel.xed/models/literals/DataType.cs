//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// datafiles/xed-operand-types.txt
        /// </summary>
        [SymSource(xed)]
        public enum DataType : byte
        {
            INVALID = 0,

            I1,

            I8,

            I16,

            I32,

            I64,

            U8,

            U16,

            U32,

            U64,

            U128,

            U256,

            F32,

            F64,

            F80,

            B80
        }
    }
}