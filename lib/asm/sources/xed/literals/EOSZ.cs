//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// Defines symbols to represent effective operands sizes
        /// </summary>
        [SymSource(xed)]
        public enum EOSZ : sbyte
        {
            [Symbol("eosz8", "Indicates an effective operand size of 8 bits")]
            W8 = 0,

            [Symbol("eosz16", "Indicates an effective operand size of 16 bits")]
            W16 = 1,

            [Symbol("eosz32", "Indicates an effective operand size of 32 bits")]
            W32 = 2,

            [Symbol("eosz64", "Indicates an effective operand size of 64 bits")]
            W64 = 3,

            [Symbol("not_eosz16", "Indicates an effective operand other than 16 bits")]
            Not16 = W8 | W32 | W64,

            [Symbol("eosznot64", "Indicates an effective operand other than 64 bits")]
            Not64 = W8 | W16 | W32
        }
    }
}