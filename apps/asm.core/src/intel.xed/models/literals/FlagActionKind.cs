//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-extension-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// xed-flag-action-enum.h
        /// </summary>
        [SymSource(state)]
        public enum FlagActionKind
        {
            [Symbol("u", "undefined (treated as a write)")]
            Undefined,

            [Symbol("tst", "test (read)")]
            Test,

            [Symbol("mod", "modification (write)")]
            Modify,

            [Symbol("0", "value will be zero (write)")]
            Disable,

            [Symbol("pop", "value comes from the stack (write)")]
            Pop,

            [Symbol("ah", "value comes from AH (write)")]
            AH,

            [Symbol("1", "value will be 1 (write)")]
            Enable,
        }
    }
}